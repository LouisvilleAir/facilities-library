'***********************************************************************************************************************
'Assembly Name: APCD.Facilities
'Filename: Plants.vb
'Author: Mike Farris
'Date: 10/03/2011
'Description: Custom collection class for the Plant business object.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports APCD.Facilities.Business

Namespace APCD.Facilities.Collections

    <Serializable()> Public Class Plants
        Inherits CollectionBase

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        Private m_htblPlant As Hashtable = New Hashtable

#End Region '----- Member Variables -----

#Region "----- Helper Methods -----"

        Public Sub Add(ByVal objPlant As Plant)

            Dim intHashCode As Int32

            Try
                intHashCode = objPlant.GetHashCode()
                Me.m_htblPlant.Add(intHashCode, objPlant)
                Me.InnerList.Add(objPlant)
            Catch ex As ArgumentException
                'thrown when a dupe is entered into the hashtble, ignore it
            End Try

        End Sub

        Public Sub Remove(ByVal objPlant As Plant)

            Dim intHashCode As Int32

            intHashCode = objPlant.GetHashCode()
            If (Me.m_htblPlant.Contains(intHashCode)) Then
                Me.m_htblPlant.Remove(intHashCode)
            End If

        End Sub

        Default Public ReadOnly Property Item(ByVal intIndex As Int32) As Plant

            Get
                Return CType(Me.InnerList(intIndex), Plant)
            End Get

        End Property

        Default Public ReadOnly Property Item(ByVal hashCode As Object) As Plant

            Get
                Return CType(Me.m_htblPlant.Item(hashCode), Plant)
            End Get

        End Property

        Public Function Contains(ByVal objPlant As Plant) As Boolean

            Dim intHashCode As Int32

            intHashCode = objPlant.GetHashCode()
            Return Me.m_htblPlant.Contains(intHashCode)

        End Function

#End Region '----- Helper Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
