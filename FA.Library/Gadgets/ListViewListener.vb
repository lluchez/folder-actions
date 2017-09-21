Imports System.Windows.Forms
Imports System.Security.Permissions


Namespace Gadgets

    Public Class ListViewListener
        Inherits NativeWindow


#Region "Members and Constants"

        '** Objects
        Protected WithEvents _listView As ListView

        '** Resize column related
        Protected _colToResizeIdx As Integer, _lastColIdx As Integer
        Protected _working As Boolean = False
        Protected _resizingCol As Integer = -1
        Protected Const WM_PAINT As Integer = 15 '0xf

        '** Fix items check issue
        Protected _checkedFirstChange As Boolean = True
        Protected _itemsChecked As Integer = 0
        Public Event ItemChecked As EventHandler(Of ItemCheckedEventArgs)

#End Region


#Region "Constructor"

        Public Sub New(ByVal lv As ListView, Optional ByVal columnToResize As Integer = -1)
            _listView = lv

            _lastColIdx = lv.Columns.Count - 1
            If columnToResize = -1 Then columnToResize = _lastColIdx
            _colToResizeIdx = columnToResize

            'AddHandler lv.ColumnWidthChanging, AddressOf ListView_ColumnWidthChanging
            'AddHandler lv.ColumnWidthChanged, AddressOf ListView_ColumnWidthChanged
            'AddHandler lv.ItemChecked, AddressOf ListView_ItemChecked
        End Sub

#End Region


#Region "Overrides WndProc/ReleaseHandle"

        '[PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")] 
        'Protected Overrides Sub WndProc(ByRef m As Message)
        'Try
        '    Select Case m.Msg
        '        Case WM_PAINT
        '            'If (_listView.View = View.Details) AndAlso (_listView.Columns.Count > 0) Then
        '            If _working Or _resizingCol >= 0 Then
        '                MyBase.WndProc(m)
        '                Return
        '            End If
        '            Me.AutoResize()
        '            'End If
        '    End Select
        'Catch ex As Exception
        '    Throw
        'Finally
        '    MyBase.WndProc(m)
        'End Try
        'End Sub

        Public Overrides Sub ReleaseHandle()
            MyBase.ReleaseHandle()
        End Sub

#End Region


#Region "Events"

        Private Sub _listView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles _listView.KeyDown
            Select Case e.KeyCode
                Case Keys.Space
                    If _listView.View <> View.Details Then
                        If (Not _listView.SelectedItems.Contains(_listView.FocusedItem)) Then
                            _listView.FocusedItem = Nothing
                        End If
                        e.SuppressKeyPress = True
                        e.Handled = True
                        Dim checked As Boolean = True
                        For Each item As ListViewItem In _listView.SelectedItems
                            checked = checked And item.Checked
                        Next
                        For Each item As ListViewItem In _listView.SelectedItems
                            item.Checked = Not checked
                        Next
                    End If
                Case Keys.A
                    If e.Control Then
                        If _listView.Items.Count = _listView.SelectedItems.Count Then Return
                        For Each item As ListViewItem In _listView.Items
                            item.Selected = True
                        Next
                    End If
            End Select
        End Sub



        'Private Sub ListView_ColumnWidthChanging(ByVal sender As Object, ByVal e As ColumnWidthChangingEventArgs) 'Handles _listView.ColumnWidthChanging
        '    '_resizingCol = e.ColumnIndex
        'End Sub

        'Private Sub ListView_ColumnWidthChanged(ByVal sender As Object, ByVal e As ColumnWidthChangedEventArgs) 'Handles _listView.ColumnWidthChanged
        '    'Dim resizeLast As Boolean = (_resizingCol <> -1)
        '    '_resizingCol = -1
        '    'If resizeLast Then Me.AutoResizeLastColumn()
        'End Sub

        Private Sub _listView_SizeChanged(sender As Object, e As System.EventArgs) Handles _listView.SizeChanged
            'If (_listView.View = View.Details) AndAlso (_listView.Columns.Count > 0) Then
            'If _working Or _resizingCol >= 0 Then Return
            Me.AutoResize()
            'End If
        End Sub

        Private Sub ListView_ItemChecked(ByVal sender As Object, ByVal e As ItemCheckedEventArgs) Handles _listView.ItemChecked
            If _listView.View <> View.Details OrElse Gadgets.Toolbox.FixListViewModifierKey(e, Form.ModifierKeys, _checkedFirstChange) Then
                _itemsChecked += CInt(IIf(e.Item.Checked, 1, -1))
                RaiseEvent ItemChecked(Me, e)
            End If
        End Sub

#End Region


#Region "Public functions and properties"

        Public Sub AutoResize()
            '_working = True
            If _colToResizeIdx <> _lastColIdx Then
                Dim lastColWidth As Integer = _listView.Columns(_lastColIdx).Width
                Me.AutoResizeLastColumn()
                Dim diff As Integer = _listView.Columns(_lastColIdx).Width - lastColWidth
                If diff > 0 Then  '** diff>0 => last col is bigger
                    _listView.Columns(_lastColIdx).Width = lastColWidth
                    _listView.Columns(_colToResizeIdx).Width += diff
                ElseIf diff < 0 Then '** diff<0 => last col is smaller
                    _listView.Columns(_colToResizeIdx).Width += diff
                    _listView.Columns(_lastColIdx).Width = lastColWidth
                Else
                    _listView.Columns(_colToResizeIdx).Width = -1
                    Me.AutoResizeLastColumn()
                    diff = _listView.Columns(_lastColIdx).Width - lastColWidth
                    _listView.Columns(_lastColIdx).Width = lastColWidth
                    _listView.Columns(_colToResizeIdx).Width += diff
                End If
            Else
                Me.AutoResizeLastColumn()
            End If
            '_working = False
        End Sub

        Public Sub AutoResizeLastColumn()
            _listView.Columns(_lastColIdx).Width = -2
        End Sub

        Public Sub AutoResizeAllColumns()
            For i As Integer = 1 To _lastColIdx
                If i <> _colToResizeIdx Then _listView.Columns(i).Width = -1
            Next
            Me.AutoResize()
        End Sub


        Public Sub AddItemToListView(ByVal item As ListViewItem)
            _listView.Items.Add(item)
            If item.Checked Then _itemsChecked += 1
            Me.AutoResizeAllColumns()
        End Sub

        Public Sub AddItemsToListView(ByVal items() As ListViewItem)
            _listView.Items.AddRange(items)
            For Each item As ListViewItem In items
                If item.Checked Then _itemsChecked += 1
            Next
            Me.AutoResizeAllColumns()
        End Sub

        Public Sub AddItemsToListView(ByVal items As List(Of ListViewItem))
            Me.AddItemsToListView(items.ToArray)
        End Sub

        Public Sub ClearListViewItems()
            _listView.Items.Clear()
            _itemsChecked = 0
        End Sub

        Public ReadOnly Property CheckedItems() As Integer
            Get
                Return _itemsChecked
            End Get
        End Property

#End Region


    End Class

End Namespace
