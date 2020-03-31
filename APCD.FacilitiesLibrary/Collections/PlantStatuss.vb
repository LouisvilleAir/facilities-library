'***********************************************************************************************************************
'Assembly Name: APCD.Facilities
'Filename: PlantStatuss.vb
'Author: Mike Farris
'Date: 10/03/2011
'Description: Custom collection class for the PlantStatus business object.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports APCD.Facilities.Business

Namespace APCD.Facilities.Collections

    <Serializable()> Public Class PlantStatuss
        Inherits CollectionBase

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        Private m_htblPlantStatus As Hashtable = New Hashtable

#End Region '----- Member Variables -----

#Region "----- Helper Methods -----"

        Public Sub Add(ByVal objPlantStatus As PlantStatus)

            Dim intHashCode As Int32

            Try
                intHashCode = objPlantStatus.GetHashCode()
                Me.m_htblPlantStatus.Add(intHashCode, objPlantStatus)
                Me.InnerList.Add(objPlantStatus)
            Catch ex As ArgumentException
                'thrown when a dupe is entered into the hashtble, ignore it
            End Try

        End Sub

        Public Sub Remove(ByVal objPlantStatus As PlantStatus)

            Dim intHashCode As Int32

            intHashCode = objPlantStatus.GetHashCode()
            If (Me.m_htblPlantStatus.Contains(intHashCode)) Then
                Me.m_htblPlantStatus.Remove(intHashCode)
            End If

        End Sub

        Default Public ReadOnly Property Item(ByVal intIndex As Int32) As PlantStatus

            Get
                Return CType(Me.InnerList(intIndex), PlantStatus)
            End Get

        End Property

        Default Public ReadOnly Property Item(ByVal hashCode As Object) As PlantStatus

            Get
                Return CType(Me.m_htblPlantStatus.Item(hashCode), PlantStatus)
            End Get

        End Property

        Public Function Contains(ByVal objPlantStatus As PlantStatus) As Boolean

            Dim intHashCode As Int32

            intHashCode = objPlantStatus.GetHashCode()
            Return Me.m_htblPlantStatus.Contains(intHashCode)

        End Function

#End Region '----- Helper Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
