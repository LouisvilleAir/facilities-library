'***********************************************************************************************************************
'Assembly Name: APCD.Facilities
'Filename: PlantClasss.vb
'Author: Mike Farris
'Date: 10/03/2011
'Description: Custom collection class for the PlantClass business object.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports APCD.Facilities.Business

Namespace APCD.Facilities.Collections

    <Serializable()> Public Class PlantClasss
        Inherits CollectionBase

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        Private m_htblPlantClass As Hashtable = New Hashtable

#End Region '----- Member Variables -----

#Region "----- Helper Methods -----"

        Public Sub Add(ByVal objPlantClass As PlantClass)

            Dim intHashCode As Int32

            Try
                intHashCode = objPlantClass.GetHashCode()
                Me.m_htblPlantClass.Add(intHashCode, objPlantClass)
                Me.InnerList.Add(objPlantClass)
            Catch ex As ArgumentException
                'thrown when a dupe is entered into the hashtble, ignore it
            End Try

        End Sub

        Public Sub Remove(ByVal objPlantClass As PlantClass)

            Dim intHashCode As Int32

            intHashCode = objPlantClass.GetHashCode()
            If (Me.m_htblPlantClass.Contains(intHashCode)) Then
                Me.m_htblPlantClass.Remove(intHashCode)
            End If

        End Sub

        Default Public ReadOnly Property Item(ByVal intIndex As Int32) As PlantClass

            Get
                Return CType(Me.InnerList(intIndex), PlantClass)
            End Get

        End Property

        Default Public ReadOnly Property Item(ByVal hashCode As Object) As PlantClass

            Get
                Return CType(Me.m_htblPlantClass.Item(hashCode), PlantClass)
            End Get

        End Property

        Public Function Contains(ByVal objPlantClass As PlantClass) As Boolean

            Dim intHashCode As Int32

            intHashCode = objPlantClass.GetHashCode()
            Return Me.m_htblPlantClass.Contains(intHashCode)

        End Function

#End Region '----- Helper Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
