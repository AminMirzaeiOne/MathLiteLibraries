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









End Module
