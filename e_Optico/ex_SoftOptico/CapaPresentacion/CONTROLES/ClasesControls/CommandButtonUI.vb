'Imports System.ComponentModel
'Imports System.Data
'Imports System.Drawing
'Imports System.Drawing.Drawing2D
'Imports System.Linq
'Imports System.Windows.Forms
'Imports MaterialSkin
'Imports MaterialSkin.Animations

'Namespace MaterialSkin.Controls
'    Public Class CommandButtonUI
'        Inherits ComboBox
'        Implements IMaterialControl

'        ' For some reason, even when overriding the AutoSize property, it doesn't appear on the properties panel, so we have to create a new one.
'        <Browsable(True), EditorBrowsable(EditorBrowsableState.Always), Category("Layout")>
'        Private _AutoResize As Boolean

'        Public Property AutoResize As Boolean
'            Get
'                Return _AutoResize
'            End Get
'            Set(value As Boolean)
'                _AutoResize = value
'                recalculateAutoSize()
'            End Set
'        End Property

'        'Properties for managing the material design properties
'        <Browsable(False)>
'        Public Property Depth As Integer Implements IMaterialControl.Depth

'        <Browsable(False)>
'        Public ReadOnly Property SkinManager As MaterialSkinManager Implements IMaterialControl.SkinManager
'            Get
'                Return MaterialSkinManager.Instance
'            End Get
'        End Property

'        <Browsable(False)>
'        Public Property MouseState As MouseState Implements IMaterialControl.MouseState

'        Private _UseTallSize As Boolean

'        <Category("Material Skin"), DefaultValue(True), Description("Using a larger size enables the hint to always be visible")>
'        Public Property UseTallSize As Boolean
'            Get
'                Return _UseTallSize
'            End Get
'            Set(value As Boolean)
'                _UseTallSize = value
'                setHeightVars()
'                Invalidate()
'            End Set
'        End Property

'        <Category("Material Skin"), DefaultValue(True)>
'        Public Property UseAccent As Boolean

'        Private _hint As String = String.Empty

'        <Category("Material Skin"), DefaultValue(""), Localizable(True)>
'        Public Property Hint As String
'            Get
'                Return _hint
'            End Get
'            Set(value As String)
'                _hint = value
'                hasHint = Not String.IsNullOrEmpty(Hint)
'                Invalidate()
'            End Set
'        End Property

'        Private _startIndex As Integer
'        Public Property StartIndex As Integer
'            Get
'                Return _startIndex
'            End Get
'            Set(value As Integer)
'                _startIndex = value
'                Try
'                    If MyBase.Items.Count > 0 Then
'                        MyBase.SelectedIndex = value
'                    End If
'                Catch
'                End Try
'                Invalidate()
'            End Set
'        End Property

'        Private Const TEXT_SMALL_SIZE As Integer = 18
'        Private Const TEXT_SMALL_Y As Integer = 4
'        Private Const BOTTOM_PADDING As Integer = 3
'        Private HEIGHT As Integer = 50
'        Private LINE_Y As Integer

'        Private hasHint As Boolean

'        'Private ReadOnly _animationManager As AnimationManager

'        Public Sub New()
'            SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw, True)

'            ' Material Properties
'            Hint = ""
'            UseAccent = True
'            UseTallSize = True
'            MaxDropDownItems = 4

'            Font = SkinManager.getFontByType(MaterialSkinManager.fontType.Subtitle2)
'            BackColor = SkinManager.BackgroundColor
'            ForeColor = SkinManager.TextHighEmphasisColor
'            DrawMode = DrawMode.OwnerDrawVariable
'            DropDownStyle = ComboBoxStyle.DropDownList
'            DropDownWidth = Width

'            ' Animations
'            _animationManager = New AnimationManager(True) With {
'                .Increment = 0.08,
'                .AnimationType = AnimationType.EaseInOut
'            }

'            AddHandler _animationManager.OnAnimationProgress, Sub() Invalidate()
'            AddHandler _animationManager.OnAnimationFinished, Sub() _animationManager.SetProgress(0)

'            AddHandler DropDownClosed, Sub(sender, args)
'                                           MouseState = MouseState.OUT
'                                           If SelectedIndex < 0 AndAlso Not Focused Then
'                                               _animationManager.StartNewAnimation(AnimationDirection.Out)
'                                           End If
'                                       End Sub

'            AddHandler LostFocus, Sub(sender, args)
'                                      MouseState = MouseState.OUT
'                                      If SelectedIndex < 0 Then
'                                          _animationManager.StartNewAnimation(AnimationDirection.Out)
'                                      End If
'                                  End Sub

'            AddHandler DropDown, Sub(sender, args) _animationManager.StartNewAnimation(AnimationDirection.In)

'            AddHandler GotFocus, Sub(sender, args)
'                                     _animationManager.StartNewAnimation(AnimationDirection.In)
'                                     Invalidate()
'                                 End Sub

'            AddHandler MouseEnter, Sub(sender, args)
'                                       MouseState = MouseState.HOVER
'                                       Invalidate()
'                                   End Sub

'            AddHandler MouseLeave, Sub(sender, args)
'                                       MouseState = MouseState.OUT
'                                       Invalidate()
'                                   End Sub

'            AddHandler SelectedIndexChanged, Sub(sender, args) Invalidate()

'            AddHandler KeyUp, Sub(sender, args)
'                                  If Enabled AndAlso DropDownStyle = ComboBoxStyle.DropDownList AndAlso (args.KeyCode = Keys.Delete OrElse args.KeyCode = Keys.Back) Then
'                                      SelectedIndex = -1
'                                      Invalidate()
'                                  End If
'                              End Sub
'        End Sub

'        Public Sub ResetToDefaultColors()
'            BackColor = SkinManager.BackgroundColor
'            ForeColor = SkinManager.TextHighEmphasisColor
'            Font = SkinManager.getFontByType(MaterialSkinManager.fontType.Subtitle2)
'            Invalidate()
'        End Sub

'        Protected Overrides Sub OnPaint(pevent As PaintEventArgs)
'            Dim g As Graphics = pevent.Graphics

'            g.Clear(Parent.BackColor)

'            Using roundedRectPath As GraphicsPath = DrawHelper.CreateRoundRect(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, LINE_Y, 4)
'                Dim fillBrush As SolidBrush
'                If Enabled Then
'                    If Focused Then
'                        fillBrush = New SolidBrush(SkinManager.BackgroundFocusColor) ' Focused
'                    ElseIf MouseState = MouseState.HOVER Then
'                        fillBrush = New SolidBrush(SkinManager.BackgroundHoverColor) ' Hover
'                    Else
'                        fillBrush = New SolidBrush(SkinManager.BackgroundAlternativeColor) ' Normal
'                    End If
'                Else
'                    fillBrush = New SolidBrush(SkinManager.BackgroundDisabledColor) ' Disabled
'                End If

'                g.FillPath(fillBrush, roundedRectPath)
'                fillBrush.Dispose()
'            End Using


'            'Set color and brush
'            Dim SelectedColor As Color
'            If UseAccent Then
'                SelectedColor = SkinManager.ColorScheme.AccentColor
'            Else
'                SelectedColor = SkinManager.ColorScheme.PrimaryColor
'            End If
'            Dim SelectedBrush As New SolidBrush(SelectedColor)

'            ' Create and Draw the arrow
'            Using pth As New GraphicsPath()
'                Dim TopRight As New PointF(Me.Width - 0.5F - SkinManager.FORM_PADDING, (Me.HEIGHT >> 1) - 2.5F)
'                Dim MidBottom As New PointF(Me.Width - 4.5F - SkinManager.FORM_PADDING, (Me.HEIGHT >> 1) + 2.5F)
'                Dim TopLeft As New PointF(Me.Width - 8.5F - SkinManager.FORM_PADDING, (Me.HEIGHT >> 1) - 2.5F)
'                pth.AddLine(TopLeft, TopRight)
'                pth.AddLine(TopRight, MidBottom)

'                g.SmoothingMode = SmoothingMode.AntiAlias

'                Dim arrowBrush As Brush
'                If Enabled Then
'                    If DroppedDown OrElse Focused Then
'                        arrowBrush = SelectedBrush 'DroppedDown or Focused
'                    Else
'                        arrowBrush = SkinManager.TextHighEmphasisBrush 'Not DroppedDown and not Focused
'                    End If
'                Else
'                    arrowBrush = New SolidBrush(DrawHelper.BlendColor(SkinManager.TextHighEmphasisColor, SkinManager.SwitchOffDisabledThumbColor, 197)) 'Disabled
'                End If

'                g.FillPath(arrowBrush, pth)
'                If Not Enabled Then arrowBrush.Dispose()

'                g.SmoothingMode = SmoothingMode.None
'            End Using


'            ' HintText
'            Dim userTextPresent As Boolean = SelectedIndex >= 0
'            Dim hintRect As New Rectangle(SkinManager.FORM_PADDING, ClientRectangle.Y, Width, LINE_Y)
'            Dim hintTextSize As Integer = 16

'            ' bottom line base
'            g.FillRectangle(SkinManager.DividersAlternativeBrush, 0, LINE_Y, Width, 1)

'            If Not _animationManager.IsAnimating() Then
'                ' No animation
'                If hasHint AndAlso UseTallSize AndAlso (DroppedDown OrElse Focused OrElse SelectedIndex >= 0) Then
'                    ' hint text
'                    hintRect = New Rectangle(SkinManager.FORM_PADDING, TEXT_SMALL_Y, Width, TEXT_SMALL_SIZE)
'                    hintTextSize = 12
'                End If

'                ' bottom line
'                If DroppedDown OrElse Focused Then
'                    g.FillRectangle(SelectedBrush, 0, LINE_Y, Width, 2)
'                End If
'            Else
'                ' Animate - Focus got/lost
'                Dim animationProgress As Double = _animationManager.GetProgress()

'                ' hint Animation
'                If hasHint AndAlso UseTallSize Then
'                    Dim animatedY As Integer = If(userTextPresent AndAlso Not _animationManager.IsAnimating(), TEXT_SMALL_Y, ClientRectangle.Y + CInt((TEXT_SMALL_Y - ClientRectangle.Y) * animationProgress))
'                    Dim animatedHeight As Integer = If(userTextPresent AndAlso Not _animationManager.IsAnimating(), TEXT_SMALL_SIZE, CInt(LINE_Y + (TEXT_SMALL_SIZE - LINE_Y) * animationProgress))
'                    hintRect = New Rectangle(SkinManager.FORM_PADDING, animatedY, Width, animatedHeight)
'                    hintTextSize = If(userTextPresent AndAlso Not _animationManager.IsAnimating(), 12, CInt(16 + (12 - 16) * animationProgress))
'                End If

'                ' Line Animation
'                Dim LineAnimationWidth As Integer = CInt(Width * animationProgress)
'                Dim LineAnimationX As Integer = (Width / 2) - (LineAnimationWidth / 2)
'                g.FillRectangle(SelectedBrush, LineAnimationX, LINE_Y, LineAnimationWidth, 2)
'            End If

'            ' Calc text Rect
'            Dim textRectY As Integer = If(hasHint AndAlso UseTallSize, (hintRect.Y + hintRect.Height) - 2, ClientRectangle.Y)
'            Dim textRectHeight As Integer = If(hasHint AndAlso UseTallSize, LINE_Y - (hintRect.Y + hintRect.Height), LINE_Y)
'            Dim textRect As New Rectangle(SkinManager.FORM_PADDING, textRectY, ClientRectangle.Width - SkinManager.FORM_PADDING * 3 - 8, textRectHeight)

'            g.Clip = New Region(textRect)

'            Using NativeText As New NativeTextRenderer(g)
'                ' Draw user text
'                NativeText.DrawTransparentText(
'                    Text,
'                    SkinManager.getLogFontByType(MaterialSkinManager.fontType.Subtitle1),
'                    If(Enabled, SkinManager.TextHighEmphasisColor, SkinManager.TextDisabledOrHintColor),
'                    textRect.Location,
'                    textRect.Size,
'                    NativeTextRenderer.TextAlignFlags.Left Or NativeTextRenderer.TextAlignFlags.Middle)
'            End Using

'            g.ResetClip()

'            ' Draw hint text
'            If hasHint AndAlso (UseTallSize OrElse String.IsNullOrEmpty(Text)) Then
'                Using NativeText As New NativeTextRenderer(g)
'                    Dim hintColor As Color
'                    If Enabled Then
'                        hintColor = If(DroppedDown OrElse Focused, SelectedColor, SkinManager.TextMediumEmphasisColor)
'                    Else
'                        hintColor = SkinManager.TextDisabledOrHintColor
'                    End If

'                    NativeText.DrawTransparentText(
'                        Hint,
'                        SkinManager.getTextBoxFontBySize(hintTextSize),
'                        hintColor,
'                        hintRect.Location,
'                        hintRect.Size,
'                        NativeTextRenderer.TextAlignFlags.Left Or NativeTextRenderer.TextAlignFlags.Middle)
'                End Using
'            End If

'            SelectedBrush.Dispose()
'        End Sub

'        Private Sub CustomMeasureItem(sender As Object, e As MeasureItemEventArgs)
'            e.ItemHeight = HEIGHT - 7
'        End Sub

'        Private Sub CustomDrawItem(sender As Object, e As DrawItemEventArgs)
'            If e.Index < 0 OrElse e.Index > Items.Count OrElse Not Focused Then Return

'            Dim g As Graphics = e.Graphics

'            ' Draw the background of the item.
'            g.FillRectangle(SkinManager.BackgroundBrush, e.Bounds)

'            ' Hover
'            If e.State.HasFlag(DrawItemState.Focus) Then ' Focus == hover
'                g.FillRectangle(SkinManager.BackgroundHoverBrush, e.Bounds)
'            End If

'            Dim drawText As String = ""
'            If Not String.IsNullOrWhiteSpace(DisplayMember) Then
'                If Not Items(e.Index).GetType().Equals(GetType(DataRowView)) Then
'                    Dim itemProperty = Items(e.Index).GetType().GetProperty(DisplayMember).GetValue(Items(e.Index), Nothing)
'                    drawText = itemProperty.ToString()
'                Else
'                    Dim row As DataRow = CType(Items(e.Index), DataRowView).Row
'                    drawText = row(DisplayMember).ToString()
'                End If
'            Else
'                drawText = Items(e.Index).ToString()
'            End If

'            Using NativeText As New NativeTextRenderer(g)
'                NativeText.DrawTransparentText(
'                    drawText,
'                    SkinManager.getFontByType(MaterialSkinManager.fontType.Subtitle1),
'                    SkinManager.TextHighEmphasisNoAlphaColor,
'                    New Point(e.Bounds.Location.X + SkinManager.FORM_PADDING, e.Bounds.Location.Y),
'                    New Size(e.Bounds.Size.Width - SkinManager.FORM_PADDING * 2, e.Bounds.Size.Height),
'                    NativeTextRenderer.TextAlignFlags.Left Or NativeTextRenderer.TextAlignFlags.Middle)
'            End Using
'        End Sub

'        Protected Overrides Sub OnCreateControl()
'            MyBase.OnCreateControl()
'            MouseState = MouseState.OUT
'            AddHandler MyBase.MeasureItem, AddressOf CustomMeasureItem
'            AddHandler MyBase.DrawItem, AddressOf CustomDrawItem
'            DropDownStyle = ComboBoxStyle.DropDownList
'            DrawMode = DrawMode.OwnerDrawVariable
'            recalculateAutoSize()
'            setHeightVars()
'        End Sub

'        Protected Overrides Sub OnResize(e As EventArgs)
'            MyBase.OnResize(e)
'            recalculateAutoSize()
'            setHeightVars()
'        End Sub

'        Private Sub setHeightVars()
'            HEIGHT = If(UseTallSize, 50, 36)
'            Size = New Size(Size.Width, HEIGHT)
'            LINE_Y = HEIGHT - BOTTOM_PADDING
'            ItemHeight = HEIGHT - 7
'            DropDownHeight = ItemHeight * MaxDropDownItems + 2
'        End Sub

'        Public Sub recalculateAutoSize()
'            If Not AutoResize Then Return

'            Dim w As Integer = DropDownWidth
'            Dim padding As Integer = SkinManager.FORM_PADDING * 3
'            Dim vertScrollBarWidth As Integer = If(Items.Count > MaxDropDownItems, SystemInformation.VerticalScrollBarWidth, 0)

'            Dim g As Graphics = CreateGraphics()
'            Using NativeText As New NativeTextRenderer(g)
'                Dim itemsList = Me.Items.Cast(Of Object)().[Select](Function(item) item.ToString())
'                For Each s As String In itemsList
'                    Dim newWidth As Integer = NativeText.MeasureLogString(s, SkinManager.getLogFontByType(MaterialSkinManager.fontType.Subtitle1)).Width + vertScrollBarWidth + padding
'                    If w < newWidth Then
'                        w = newWidth
'                    End If
'                Next
'            End Using
'            g.Dispose()

'            If Width <> w Then
'                DropDownWidth = w
'                Width = w
'            End If
'        End Sub

'    End Class
'End Namespace