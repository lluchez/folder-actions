Imports System.Windows.Forms
Imports System.Drawing


Namespace Gadgets

    Public Class TextBoxWithImage
        Inherits TextBox

        Friend WithEvents _picture As PictureBox

        Public Sub New()
            Me.InitializeComponent()
        End Sub


        Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(TextBoxWithImage))
            _picture = New PictureBox()

            _picture.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
            _picture.Name = "PctBoxInner"
            _picture.SizeMode = PictureBoxSizeMode.AutoSize
            _picture.TabIndex = 0
            _picture.TabStop = False

            Me.Controls.Add(_picture)
            'Me.Image = My.Resources.help
        End Sub


        Public WriteOnly Property Image() As Image
            Set(img As Image)
                _picture.Image = img
                _picture.Location = New Point(Me.Width - img.Width - 4, CInt(Math.Floor(Me.Height - img.Height) / 2) - 2)
                _picture.Size = img.Size
            End Set
        End Property

    End Class

End Namespace
