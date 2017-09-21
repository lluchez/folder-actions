Imports System.Windows.Forms
Imports System.Drawing


Namespace Gadgets

    Public Class Toolbox

        Public Shared Sub AdjustComboBoxWidth(ByVal dropdown As Windows.Forms.ComboBox)
            Dim g As Graphics = dropdown.CreateGraphics()
            Dim width As Integer = dropdown.Width
            Dim vertScrollBarWidth As Integer = CInt(IIf(dropdown.Items.Count > dropdown.MaxDropDownItems, SystemInformation.VerticalScrollBarWidth, 0))
            For Each item As Object In dropdown.Items
                Dim w As Integer = CInt(g.MeasureString(item.ToString, dropdown.Font).Width) + vertScrollBarWidth
                If width < w Then width = w
            Next
            If width > dropdown.MaximumSize.Width Then width = dropdown.MaximumSize.Width
            dropdown.Width = width
        End Sub

        Public Shared Function FixListViewModifierKey(ByVal e As ItemCheckedEventArgs, modifierKey As Keys, ByRef fixFirstChangeOUT As Boolean) As Boolean
            If ((modifierKey = Keys.Control) Or (modifierKey = Keys.Shift)) Then
                If fixFirstChangeOUT Then
                    fixFirstChangeOUT = False
                    e.Item.Checked = Not e.Item.Checked
                Else
                    fixFirstChangeOUT = True
                End If
                Return False
            End If
            Return True
        End Function

        Public Shared ReadOnly BgColorError As Color = Color.FromArgb(255, 200, 200)

        Public Shared Function IsInError(ByVal bgColor As Color) As Boolean
            Return (bgColor = BgColorError)
        End Function
        Public Shared Function IsOk(ByVal bgColor As Color) As Boolean
            Return (bgColor <> BgColorError)
        End Function

        Public Shared Function GetBackgroundColor(ByVal ok As Boolean) As Color
            Return CType(IIf(ok, Color.White, BgColorError), Color)
        End Function

    End Class

End Namespace
