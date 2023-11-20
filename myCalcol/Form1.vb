Imports System.Reflection.Emit

Public Class Form1

    Dim firstNum, secondNum, ans As Double
    Dim op As String

    Private Sub ResetCalcualtor()
        TextBox1.Clear()
        Label1.Text = ""
        firstNum = False
        secondNum = False
        op = False
        ans = False
    End Sub

    Private Sub EnableCalculator()
        For Each button As Button In {Button4, Button8, Button12, Button16, Button16, Button17, Button19}
            button.Enabled = True
        Next
    End Sub

    Private Sub DisableCalculator()
        For Each button As Button In {Button4, Button8, Button12, Button16, Button16, Button17, Button19}
            button.Enabled = False
        Next
    End Sub

    Private Sub Numbers_Click(sender As Object, e As EventArgs) Handles Button5.Click, Button6.Click, Button7.Click, Button9.Click, Button10.Click, Button11.Click, Button13.Click, Button14.Click, Button15.Click, Button18.Click, Button19.Click

        Dim b As Button = sender

        If TextBox1.Text.Contains("is") Or TextBox1.Text.Contains("by") Or Label1.Text.Contains("=") Then
            ResetCalcualtor()
            EnableCalculator()
        End If

        If TextBox1.Text = "0" Then
            TextBox1.Text = b.Text
        ElseIf b.Text = "." Then
            If Not TextBox1.Text.Contains(".") Then
                TextBox1.Text += b.Text
            End If
        Else
            TextBox1.Text += b.Text
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text.Contains("is") Or TextBox1.Text.Contains("by") Then
            ResetCalcualtor()
            EnableCalculator()
        End If
        TextBox1.Clear()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If TextBox1.Text.Contains("is") Or TextBox1.Text.Contains("by") Then
            ResetCalcualtor()
            EnableCalculator()
        End If

        ResetCalcualtor()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If TextBox1.Text.Contains("is") Or TextBox1.Text.Contains("by") Then
            ResetCalcualtor()
            EnableCalculator()
        End If

        If TextBox1.Text.Length > 0 Then
            TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1, 1)
        End If
    End Sub

    Private Sub Operators(sender As Object, e As EventArgs) Handles Button4.Click, Button8.Click, Button12.Click, Button16.Click

        Button20_Click()

        Dim ops As Button = sender

        If TextBox1.Text = "." Then
            Return
        End If

        If (Not String.IsNullOrEmpty(Label1.Text)) And (String.IsNullOrEmpty(TextBox1.Text)) Then
            op = ops.Text
            Label1.Text = Label1.Text.Substring(0, Label1.Text.Length - 1) + op
            Return
        End If

        If (TextBox1.Text = "") Then
            Return
        End If

        firstNum = TextBox1.Text
        Label1.Text = TextBox1.Text
        TextBox1.Text = ""
        op = ops.Text
        Label1.Text = Label1.Text + " " + op
    End Sub

    Private Sub Button20_Click() Handles Button20.Click

        If TextBox1.Text.Contains("is") Or TextBox1.Text.Contains("by") Then
            ResetCalcualtor()
            EnableCalculator()
        End If

        If TextBox1.Text = "." Then
            Return
        End If

        If TextBox1.Text = "" Then
            Return
        End If

        secondNum = TextBox1.Text

        Select Case op
            Case "+"
                ans = firstNum + secondNum
                TextBox1.Text = ans
                Label1.Text = firstNum.ToString + " + " + secondNum.ToString + " = " + ans.ToString
            Case "-"
                ans = firstNum - secondNum
                TextBox1.Text = ans
                Label1.Text = firstNum.ToString + " - " + secondNum.ToString + " = " + ans.ToString
            Case "*"
                ans = firstNum * secondNum
                TextBox1.Text = ans
                Label1.Text = firstNum.ToString + " * " + secondNum.ToString + " = " + ans.ToString
                If TextBox1.Text = "-0" Then
                    TextBox1.Text = "0"
                    Label1.Text = firstNum.ToString + " * " + secondNum.ToString + " = " + "0"
                End If
                If ans = "-0" Then
                    ans = "0"
                    Label1.Text = firstNum.ToString + " * " + secondNum.ToString + " = " + "0"
                End If
            Case "/"
                ans = firstNum / secondNum
                TextBox1.Text = ans
                Label1.Text = firstNum.ToString + " / " + secondNum.ToString + " = " + ans.ToString
                If firstNum = "0" Or secondNum = "0" Then
                    TextBox1.Text = "Cannot be divide by Zero"
                    Label1.Text = ""
                End If
                If firstNum = "0" And secondNum = "0" Then
                    TextBox1.Text = "Result is undefined"
                    Label1.Text = ""
                End If
        End Select

        If TextBox1.Text.Contains("by") Or TextBox1.Text.Contains("is") Then
            DisableCalculator()
        End If

    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click

        If TextBox1.Text.Length = 0 Then
            Return
        End If

        If TextBox1.Text.Contains("-") Then
            TextBox1.Text = TextBox1.Text.Remove(0, 1)
        Else

            If (TextBox1.Text = "0") Then
                Return
            End If
            TextBox1.Text = "-" + TextBox1.Text
        End If

    End Sub
End Class
