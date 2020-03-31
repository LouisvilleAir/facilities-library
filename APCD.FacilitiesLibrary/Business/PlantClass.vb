'***********************************************************************************************************************
'Assembly Name: APCD.Facilities
'Filename: PlantClass.vb
'Author: Mike Farris
'Date: 10/03/2011
'Description: Business class for the PlantClass table of the Facilities database.
'             Provides an object model as well as Insert, Update, and Delete operations for the table.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports APCD.Facilities.Data

Namespace APCD.Facilities.Business

    <Serializable()> Public Class PlantClass

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        '----- Property Variables -----
        Private m_intPlantClassID As Int32 'primary key
        Private m_strPlantClassName As String
        Private m_strPlantClassDescription As String
        Private m_intHansenAPDefnKey As Int32
        Private m_strPlantClassIMSCode As String

#End Region '----- Member Variables -----

#Region "----- Properties -----"

        Public Property PlantClassID() As Int32
            Get
                Return Me.m_intPlantClassID
            End Get
            Set(ByVal Value As Int32)
                Me.m_intPlantClassID = Value
            End Set
        End Property

        Public Property PlantClassName() As String
            Get
                Return Me.m_strPlantClassName
            End Get
            Set(ByVal Value As String)
                Me.m_strPlantClassName = Value
            End Set
        End Property

        Public Property PlantClassDescription() As String
            Get
                Return Me.m_strPlantClassDescription
            End Get
            Set(ByVal Value As String)
                Me.m_strPlantClassDescription = Value
            End Set
        End Property

        Public Property HansenAPDefnKey() As Int32
            Get
                Return Me.m_intHansenAPDefnKey
            End Get
            Set(ByVal Value As Int32)
                Me.m_intHansenAPDefnKey = Value
            End Set
        End Property

        Public Property PlantClassIMSCode() As String
            Get
                Return Me.m_strPlantClassIMSCode
            End Get
            Set(ByVal Value As String)
                Me.m_strPlantClassIMSCode = Value
            End Set
        End Property

#End Region '----- Properties -----

#Region "----- DML -----"

        Public Function Insert() As Int32

            Dim intReutrnValue As Int32
            Dim objPlantClassDB As PlantClassDB

            Try
                objPlantClassDB = New PlantClassDB
                intReutrnValue = objPlantClassDB.Insert(Me)
            Catch ex As Exception
                Throw
            End Try

            Return intReutrnValue

        End Function

        Public Function Update() As Int32

            Dim intReutrnValue As Int32
            Dim objPlantClassDB As PlantClassDB

            Try
                objPlantClassDB = New PlantClassDB
                intReutrnValue = objPlantClassDB.Update(Me)
            Catch ex As Exception
                Throw
            End Try

            Return intReutrnValue

        End Function

        Public Function Delete() As Int32

            Dim intReutrnValue As Int32
            Dim objPlantClassDB As PlantClassDB

            Try
                objPlantClassDB = New PlantClassDB
                intReutrnValue = objPlantClassDB.Delete(Me)
            Catch ex As Exception
                Throw
            End Try

            Return intReutrnValue

        End Function

#End Region '----- DML -----

#Region "----- Object Class Overloads-----"

        Public Overrides Function ToString() As String

            Dim strbToString As Text.StringBuilder

            strbToString = New Text.StringBuilder
            With strbToString

                .Append(Constants.PlantClassConstants.FieldName.PlantClassID)
                .Append(":")
                .Append(Me.PlantClassID)
                .Append(ControlChars.CrLf)

                .Append(Constants.PlantClassConstants.FieldName.PlantClassName)
                .Append(":")
                .Append(Me.PlantClassName)
                .Append(ControlChars.CrLf)

                .Append(Constants.PlantClassConstants.FieldName.PlantClassDescription)
                .Append(":")
                .Append(Me.PlantClassDescription)
                .Append(ControlChars.CrLf)

                .Append(Constants.PlantClassConstants.FieldName.HansenAPDefnKey)
                .Append(":")
                .Append(Me.HansenAPDefnKey)
                .Append(ControlChars.CrLf)

                .Append(Constants.PlantClassConstants.FieldName.PlantClassIMSCode)
                .Append(":")
                .Append(Me.PlantClassIMSCode)
                .Append(ControlChars.CrLf)

            End With

            Return strbToString.ToString()

        End Function

        Public Overrides Function GetHashCode() As Int32

            Dim intHashCode As Int32
            intHashCode = Me.PlantClassID.GetHashCode()
            Return intHashCode

        End Function

        Public Overloads Function Equals(ByVal objPlantClass As PlantClass) As Boolean

            Dim blnEquals As Boolean

            If ((Me.PlantClassID = objPlantClass.PlantClassID) _
                AndAlso (Me.PlantClassName = objPlantClass.PlantClassName) _
                AndAlso (Me.PlantClassDescription = objPlantClass.PlantClassDescription) _
                AndAlso (Me.HansenAPDefnKey = objPlantClass.HansenAPDefnKey) _
                AndAlso (Me.PlantClassIMSCode = objPlantClass.PlantClassIMSCode)) Then
                blnEquals = True
            Else
                blnEquals = False
            End If

            Return blnEquals

        End Function

#End Region '----- Object Class Overloads-----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
