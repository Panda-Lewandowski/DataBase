IF OBJECT_ID('doctors_xsd', 'U') IS NOT NULL
DROP XML SCHEMA COLLECTION doctors_xsd
GO

CREATE XML SCHEMA COLLECTION doctors_xsd
AS
'<?xml version="1.0" standalone="yes"?>
<xs:schema id="NewDataSet" xmlns="" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">
  <xs:element name="Passenger">
    <xs:complexType>
      <xs:sequence>
        <xs:element name="Survival" type="xs:string" default="Unknown" minOccurs="0" msdata:Ordinal="0" />
        <xs:element name="Name" type="xs:string" default="Unknown" minOccurs="0" msdata:Ordinal="1" />
        <xs:element name="Sex" type="xs:string" default="Unknown" minOccurs="0" msdata:Ordinal="2" />
        <xs:element name="Age" type="xs:string" default="Unknown" minOccurs="0" msdata:Ordinal="3" />
      </xs:sequence>
      <xs:attribute name="PassengerId" type="xs:string" />
    </xs:complexType>
  </xs:element>
  <xs:element name="NewDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true">
    <xs:complexType>
      <xs:choice minOccurs="0" maxOccurs="unbounded">
        <xs:element ref="Passenger" />
      </xs:choice>
    </xs:complexType>
  </xs:element>
</xs:schema>'
GO