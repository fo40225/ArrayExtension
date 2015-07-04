Imports System.Runtime.CompilerServices
Imports System.Collections.ObjectModel

Namespace ArrayExtension
    Public Module Extender
        <Extension>
        Public Function AsReadOnly(Of T)(a As T()) As ReadOnlyCollection(Of T)
            Return Array.AsReadOnly(a)
        End Function

        <Extension>
        Public Function BinarySearch(Of T)(a As T(), value As T) As Integer
            Return Array.BinarySearch(a, value)
        End Function

        <Extension>
        Public Function BinarySearch(Of T)(a As T(), index As Integer, length As Integer, value As T) As Integer
            Return Array.BinarySearch(a, index, length, value)
        End Function

        <Extension>
        Public Sub Clear(Of T)(a As T(), index As Integer, length As Integer)
            Array.Clear(a, index, length)
        End Sub

        <Extension>
        Public Sub ConstrainedCopy(Of T)(sourceArray As T(), sourceIndex As Integer, destinationArray As Array, destinationIndex As Integer, length As Integer)
            Array.ConstrainedCopy(sourceArray, sourceIndex, destinationArray, destinationIndex, length)
        End Sub

        <Extension>
        Public Function ConvertAll(Of TInput, TOutput)(a As TInput(), converter As Converter(Of TInput, TOutput)) As TOutput()
            Return Array.ConvertAll(a, converter)
        End Function

        <Extension>
        Public Sub Copy(Of T)(sourceArray As T(), destinationArray As Array, length As Long, Optional sourceIndex As Long = 0L, Optional destinationIndex As Long = 0L)
            Array.Copy(sourceArray, sourceIndex, destinationArray, destinationIndex, length)
        End Sub

        <Extension>
        Public Function Exists(Of T)(a As T(), match As Predicate(Of T)) As Boolean
            Return Array.Exists(a, match)
        End Function

        <Extension>
        Public Function Find(Of T)(a As T(), match As Predicate(Of T)) As T
            Return Array.Find(a, match)
        End Function

        <Extension>
        Public Function FindAll(Of T)(a As T(), match As Predicate(Of T)) As T()
            Return Array.FindAll(a, match)
        End Function

        <Extension>
        Public Function FindIndex(Of T)(a As T(), match As Predicate(Of T), Optional startIndex As Integer = 0, Optional count As Integer? = Nothing) As Integer
            Dim result As Integer
            If count.HasValue Then
                result = Array.FindIndex(a, startIndex, count.Value, match)
            Else
                result = Array.FindIndex(a, startIndex, match)
            End If
            Return result
        End Function

        <Extension>
        Public Function FindLast(Of T)(a As T(), match As Predicate(Of T)) As T
            Return Array.FindLast(a, match)
        End Function

        <Extension>
        Public Function FindLastIndex(Of T)(a As T(), match As Predicate(Of T), Optional startIndex As Integer = 0, Optional count As Integer? = Nothing) As Integer
            Dim result As Integer
            If count.HasValue Then
                result = Array.FindLastIndex(a, startIndex, count.Value, match)
            Else
                result = Array.FindLastIndex(a, startIndex, match)
            End If
            Return result
        End Function

        <Extension>
        Public Sub ForEach(Of T)(a As T(), action As Action(Of T))
            Array.ForEach(a, action)
        End Sub

        <Extension>
        Public Function IndexOf(Of T)(a As T(), value As T, Optional startIndex As Integer = 0, Optional count As Integer? = Nothing) As Integer
            Dim result As Integer
            If count.HasValue Then
                result = Array.IndexOf(a, value, startIndex)
            Else
                result = Array.IndexOf(a, value, startIndex, count.Value)
            End If
            Return result
        End Function

        <Extension>
        Public Function LastIndexOf(Of T)(a As T(), value As T, Optional startIndex As Integer = 0, Optional count As Integer? = Nothing) As Integer
            Dim result As Integer
            If count.HasValue Then
                result = Array.LastIndexOf(Of T)(a, value, startIndex)
            Else
                result = Array.LastIndexOf(Of T)(a, value, startIndex, count.Value)
            End If
            Return result
        End Function

        <Extension>
        Public Sub Resize(Of T)(ByRef a As T(), newSize As Integer)
            Array.Resize(a, newSize)
        End Sub

        <Extension>
        Public Sub Reverse(Of T)(a As T(), Optional index As Integer? = Nothing, Optional length As Integer? = Nothing)
            If length.HasValue AndAlso index.HasValue Then
                Array.Reverse(a, index.Value, length.Value)
            Else
                Array.Reverse(a)
            End If
        End Sub

        <Extension>
        Public Sub Sort(Of T)(a As T(), Optional comparison As Comparison(Of T) = Nothing, Optional index As Integer? = Nothing, Optional length As Integer? = Nothing)
            Dim comparer As IComparer(Of T) = Nothing
            If comparison IsNot Nothing Then
                comparer = New FunctorComparer(Of T)(comparison)
            End If
            If length.HasValue AndAlso index.HasValue Then
                Array.Sort(a, index.Value, length.Value, comparer)
            Else
                Array.Sort(a, comparer)
            End If
        End Sub

        <Extension>
        Public Function TrueForAll(Of T)(a As T(), match As Predicate(Of T)) As Boolean
            Return Array.TrueForAll(a, match)
        End Function

        Private Class FunctorComparer(Of T)
            Implements IComparer(Of T)

            Private comparison As Comparison(Of T)

            Public Sub New(comparison As Comparison(Of T))
                Me.comparison = comparison
            End Sub

            Public Function Compare(x As T, y As T) As Integer Implements IComparer(Of T).Compare
                Return Me.comparison(x, y)
            End Function
        End Class
    End Module
End Namespace