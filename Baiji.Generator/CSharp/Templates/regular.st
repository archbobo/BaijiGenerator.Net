_structbody(context) ::= <<
<_constructor(context)>

<context.Fields : { field |<_field(field)>}; separator="\n">
>>

_field(field) ::= <<
<if (tweaks.GEN_COMMENTS && field.DocStringLines)>
<_docString(field.DocStringLines)>
<endif>
<if (tweaks.GEN_PROTOBUF_ATTRIBUTE)>
[ProtoMember(<field.Id>)]
<endif>
public <field.GenType.TypeName> <field.PropertyName> { get; set; }
>>

_constructor(element) ::= <<
public <element.Name>() {
}
>>

