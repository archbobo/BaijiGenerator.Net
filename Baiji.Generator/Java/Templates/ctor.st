_structbody(context) ::= <<
<_constructor(context)>

<context.Fields : { field |<_field(field)>}; separator="\n\n">

<context.Fields : { field |<_field_getter_setter(field)>}; separator="\n\n">
>>

_field(field) ::= <<
<if (tweaks.GEN_COMMENTS && field.DocStringLines)>
<_docString(field.DocStringLines)>
<endif>
<if (tweaks.GEN_PUBLIC_FIELDS)>public<else>private<endif> <field.GenType.TypeName> <field.CodeName>;
>>

_field_getter_setter(field) ::= <<
<if (tweaks.GEN_COMMENTS && field.DocStringLines)>
<_docString(field.DocStringLines)>
<endif>
public <field.GenType.TypeName> <field.GetterName>() {
    return <field.CodeName>;
}

<if (tweaks.GEN_COMMENTS && field.DocStringLines)>
<_docString(field.DocStringLines)>
<endif>
public void <field.SetterName>(final <field.GenType.TypeName> <field.CodeName>) {
    this.<field.CodeName> = <field.CodeName>;
}
>>

_constructor(element) ::= <<
<if(element.Fields)>
public <element.Name><_params(element.Fields)> {
    <element.Fields: {field|<_ctorAssignment(field)>}; separator="\n">
}
<endif>

public <element.Name>() {
}
>>

_ctorAssignment(field) ::= <<
this.<field.CodeName> = <field.CodeName>;
>>
