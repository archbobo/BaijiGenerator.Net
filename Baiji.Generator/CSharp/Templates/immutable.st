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
public <field.GenType.TypeName> <field.PropertyName> { get; private set; }
>>

_constructor(element) ::= <<
public <element.Name><_params(element.Fields)> {
    <element.Fields: {field|<_ctorAssignment(field)>}; separator="\n">
}
>>

_ctorAssignment(field) ::= <<
this.<field.PropertyName> = <field.Name>;
>>
