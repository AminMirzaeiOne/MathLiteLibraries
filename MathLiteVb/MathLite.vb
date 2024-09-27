Module MathLite
    Public Enum RootMethod
        Newton
        Binary
    End Enum

    Public Enum PowerMethod
        LoopMethod
        Returned
    End Enum

    Private _xValues() As Double
    Private _tanhValues() As Double
    Private _step As Double

    Public Function Maximum(ParamArray numbers As Integer()) As Integer
        If numbers Is Nothing OrElse numbers.Length = 0 Then
            Throw New System.ArgumentException("Array cannot be null or empty.")
        End If

        Dim max As Integer = numbers(0)
        For i As Integer = 1 To numbers.Length - 1
            If numbers(i) > max Then
                max = numbers(i)
            End If
        Next

        Return max
    End Function


    Public Function Minimum(ParamArray numbers As Integer()) As Integer
        If numbers Is Nothing OrElse numbers.Length = 0 Then
            Throw New ArgumentException("Array cannot be null or empty.")
        End If

        Dim min As Integer = numbers(0)
        For i As Integer = 1 To numbers.Length - 1
            If numbers(i) < min Then
                min = numbers(i)
            End If
        Next

        Return min
    End Function

    Public Function Sqrt(x As Double) As Double
        If x < 0 Then
            Throw New System.ArgumentException("Cannot calculate square root of a negative number.")
        End If

        Dim y As Double = x / 2
        Dim epsilon As Double = 0.000000000000001

        While MathLite.Abs(y * y - x) > epsilon
            y = (y + x / y) / 2
        End While

        Return y
    End Function

    Public Function Sqrt(x As Double, method As MathLiteVb.MathLite.RootMethod) As Double
        Dim result As Double = 0

        If method = MathLiteVb.MathLite.RootMethod.Newton Then
            result = MathLiteVb.MathLite.Sqrt(x)
        Else
            If x < 0 Then
                Throw New System.ArgumentException("Cannot calculate square root of a negative number.")
            End If

            Dim left As Double = 0
            Dim right As Double = x
            Dim epsilon As Double = 0.000000000000001

            While right - left > epsilon
                Dim mid As Double = (left + right) / 2
                If mid * mid > x Then
                    right = mid
                Else
                    left = mid
                End If
            End While

            result = left
        End If

        Return result
    End Function

    Public Function Root(ByVal number As Double, ByVal n As Double) As Double
        If number < 0 AndAlso n Mod 2 = 0 Then
            Throw New System.ArgumentException("Cannot calculate even root of a negative number.")
        End If

        Return Math.Pow(number, 1.0 / n)
    End Function

    Public Function Abs(ByVal value As Short) As Short
        Return System.Convert.ToInt16(If(value < 0, -value, value))
    End Function

    Public Function Abs(ByVal value As Integer) As Integer
        Return If(value < 0, -value, value)
    End Function

    Public Function Abs(ByVal value As Long) As Long
        Return If(value < 0, -value, value)
    End Function

    Public Function Abs(ByVal value As Decimal) As Decimal
        Return If(value < 0, -value, value)
    End Function

    Public Function Abs(ByVal value As Single) As Single
        Return If(value < 0, -value, value)
    End Function

    Public Function Abs(ByVal value As Double) As Double
        Return If(value < 0, -value, value)
    End Function

    Public Function Abs(ByVal value As SByte) As SByte
        Return System.Convert.ToSByte(If(value < 0, -value, value))
    End Function

    Public Function Round(value As Double) As Long
        Dim signMask = &H8000000000000000UL

        Dim sign = CInt(CULng(value) And signMask) >> 63

        Dim integral As Integer = value
        Dim fractional = value - integral
        If fractional >= 0.5 Then
            integral += 1
        End If
        Return integral - sign
    End Function

    Public Function Ceiling(value As Double) As Long
        Dim integralPart As Long = value
        Dim fractionalPart = value - integralPart

        If fractionalPart > 0 Then
            Return integralPart + 1
        Else
            Return integralPart
        End If
    End Function


    Public Function Floor(value As Double) As Long
        If value >= 0 Then
            Return value
        Else
            Return CLng(value) - 1
        End If
    End Function


    Public Function Pow(baseNumber As Double, exponent As Double) As Double
        Dim result = 1.0
        If exponent >= 0 Then
            For i As Integer = 0 To exponent - 1
                result *= baseNumber
            Next
        Else
            For i As Integer = 0 To exponent + 1 Step -1
                result /= baseNumber
            Next
        End If
        Return result
    End Function


    Public Function Pow(baseNumber As Double, exponent As Double, method As MathLite.PowerMethod) As Double
        Dim resulte As Double = 0
        If method = MathLite.PowerMethod.LoopMethod Then
            resulte = MathLiteVb.MathLite.Pow(baseNumber, exponent)
        Else
            If exponent = 0 Then
                resulte = 1.0
            End If
            If exponent < 0 Then
                resulte = 1.0 / MathLite.Pow(baseNumber, -exponent)
            End If
            If exponent Mod 2 = 0 Then
                Dim temp As Double = MathLite.Pow(baseNumber, exponent / 2)
                resulte = temp * temp
            Else
                resulte = baseNumber * MathLite.Pow(baseNumber, exponent - 1)
            End If
        End If
        Return resulte
    End Function

    Public Function Cos(x As Double) As Double

        Dim result = 1.0
        Dim term = 1.0
        Dim sign = -1
        Dim i = 2

        While MathLite.Abs(term) > 0.0000000001
            term *= sign * x * x / (i * (i - 1))
            sign = -sign
            result += term
            i += 2
        End While
        Return result
    End Function

    Public Function Sin(x As Double) As Double

        Dim result = x
        Dim term = x
        Dim sign = -1
        Dim i = 3

        While MathLite.Abs(term) > 0.0000000001
            term *= -x * x / ((i - 1) * i)
            result += term
            sign *= -1
            i += 2
        End While
        Return result
    End Function

    Public Function Acos(x As Double) As Double
        If x < -1 OrElse x > 1 Then Throw New ArgumentOutOfRangeException("x must be between -1 and 1")

        Dim result As Double = MathLiteVb.Constants.PI / 2 - 2 * MathLite.Atan(x / (1 + MathLite.Sqrt(1 - x * x)))
        Return result
    End Function

    Public Function Atan(x As Double) As Double
        Dim result = x
        Dim term = x
        Dim sign = -1
        Dim i = 3

        While MathLite.Abs(term) > 0.0000000001
            term *= -x * x / (i - 1) * i
            result += term
            sign *= -1
            i += 2
        End While
        Return result
    End Function

    Public Function Asin(x As Double) As Double

        If x < -1 OrElse x > 1 Then Throw New ArgumentOutOfRangeException("x must be between -1 and 1")

        Dim result As Double = 2 * MathLite.Atan(x / (1 + MathLite.Sqrt(1 - x * x)))
        Return result
    End Function


    Public Function Cosh(x As Double) As Double
        Return (MathLite.Exp(x) + MathLite.Exp(-x)) / 2
    End Function

    Public Function Exp(x As Double) As Double
        Dim result = 1.0
        Dim term = 1.0
        Dim i = 1

        While MathLite.Abs(term) > 0.0000000001
            term *= x / i
            result += term
            i += 1
        End While
        Return result

    End Function


    Public Function BigMul(a As Integer, b As Integer) As Long
        Dim result As Long = 0
        Dim multiplier = 1

        While b <> 0
            Dim lastDigit = b Mod 10
            result += a * lastDigit * multiplier
            b /= 10
            multiplier *= 10
        End While

        Return result
    End Function

    Public Function Atan2(y As Double, x As Double) As Double
        If x = 0 Then
            If y > 0 Then Return MathLiteVb.Constants.PI / 2
            If y < 0 Then Return -MathLiteVb.Constants.PI / 2
            Return Double.NaN
        End If

        Dim theta As Double = MathLite.Atan(y / x)
        If x < 0 Then
            theta += MathLiteVb.Constants.PI
        ElseIf y < 0 AndAlso x > 0 Then
            theta += 2 * MathLiteVb.Constants.PI
        End If

        Return theta
    End Function

    Public Function Sign(number As Integer) As Integer
        If number > 0 Then
            Return 1
        ElseIf number < 0 Then
            Return -1
        Else
            Return 0
        End If
    End Function

    Public Function Tan(angle As Double) As Double
        Return MathLite.Sin(angle) / MathLite.Cos(angle)
    End Function

    Public Function Tanh(x As Double) As Double
        Dim exp_x As Double = MathLite.Exp(x)
        Dim exp_neg_x As Double = MathLite.Exp(-x)
        Return (exp_x - exp_neg_x) / (exp_x + exp_neg_x)
    End Function


    Public Function Tanh(x As Double, terms As Integer) As Double

        Dim result As Double = 0
        Dim term = x
        Dim sign = 1
        For i = 1 To terms
            result += term
            sign *= -1
            term *= x * x * (2 * i - 1) / (2 * i + 1)
        Next
        Return result
    End Function

    Public Sub TanhLookupTable(minX As Double, maxX As Double, numPoints As Integer)
        MathLite._step = (maxX - minX) / (numPoints - 1)
        MathLite._xValues = New Double(numPoints - 1) {}
        MathLite._tanhValues = New Double(numPoints - 1) {}

        For i = 0 To numPoints - 1
            _xValues(i) = minX + i * _step
            _tanhValues(i) = MathLite.Tanh(_xValues(i))
        Next
    End Sub



End Module
