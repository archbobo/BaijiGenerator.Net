service(context, tweaks, global) ::= <<
<! ================================================================================== !>
<! =                                                                                = !>
<! = service definition                                                             = !>
<! =                                                                                = !>
<! = called from the generator to render a new service java source file.            = !>
<! =                                                                                = !>
<! ================================================================================== !>

package <context.Namespace>;

import com.ctriposs.baiji.rpc.common.BaijiContract;

<if (tweaks.GEN_COMMENTS && context.DocStringLines)>
<_docString(context.DocStringLines)>
<endif>
@BaijiContract(serviceName = "<if(context.ServiceName)><context.ServiceName><endif>", serviceNamespace = "<if(context.ServiceNamespace)><context.ServiceNamespace><endif>", codeGeneratorVersion = "<global.CodeGenVersion>")
public interface <context.TypeName> {

    <context.Methods : { method |<_method(method)>}; separator="\n\n">
}
>>

client(context, tweaks, global) ::= <<
<! ================================================================================== !>
<! =                                                                                = !>
<! = client definition                                                              = !>
<! =                                                                                = !>
<! = called from the generator to render a new client java source file.             = !>
<! =                                                                                = !>
<! ================================================================================== !>
package <context.Namespace>;

import com.ctriposs.baiji.rpc.client.*;
import com.ctriposs.baiji.rpc.common.types.*;
import java.io.IOException;

<if (tweaks.GEN_COMMENTS && context.DocStringLines)>
<_docString(context.DocStringLines)>
<endif>
public class <context.TypeName> extends ServiceClientBase\<<context.TypeName>\> {
    public static final String ORIGINAL_SERVICE_NAME = "<context.ServiceName>";

    public static final String ORIGINAL_SERVICE_NAMESPACE = "<context.ServiceNamespace>";

    public static final String CODE_GENERATOR_VERSION = "<global.CodeGenVersion>";

    private <context.TypeName>(String baseUri) {
        super(<context.TypeName>.class, baseUri);
    }

    private <context.TypeName>(String serviceName, String serviceNamespace, String subEnv) throws ServiceLookupException {
        super(<context.TypeName>.class, serviceName, serviceNamespace, subEnv);
    }

    public static <context.TypeName> getInstance() {
        return ServiceClientBase.getInstance(<context.TypeName>.class);
    }

    public static <context.TypeName> getInstance(String baseUrl) {
        return ServiceClientBase.getInstance(<context.TypeName>.class, baseUrl);
    }

    <context.Methods : { method |<_clientMethod(method)>}; separator="\n">
}
>>

_clientMethod(method) ::= <<
<if (tweaks.GEN_COMMENTS && method.DocStringLines)>
<_docString(method.DocStringLines)>
<endif>
public <method.ReturnType> <method.CodeName>(<if(method.ArgumentType)><method.ArgumentType> <method.ArgumentName><endif>)
                                throws Exception {
    return super.invoke("<method.CodeName>"<if (method.ArgumentType)>, <method.ArgumentName><endif>, <method.ReturnType>.class);
}
public java.util.concurrent.Future\<<method.ReturnType>\> <method.CodeName>Async(<if(method.ArgumentType)><method.ArgumentType> <method.ArgumentName><endif>)
                                throws Exception {
    return super.invokeAsync("<method.CodeName>"<if (method.ArgumentType)>, <method.ArgumentName><endif>, <method.ReturnType>.class);
}
>>

struct(context, tweaks, global) ::= <<
<! ================================================================================== !>
<! =                                                                                = !>
<! = struct definition                                                              = !>
<! =                                                                                = !>
<! = called from the generator to render a new struct java source file.             = !>
<! =                                                                                = !>
<! ================================================================================== !>
package <context.Namespace>;

import java.util.*;
import com.ctriposs.baiji.exception.*;
import com.ctriposs.baiji.rpc.common.*;
import com.ctriposs.baiji.schema.*;
import com.ctriposs.baiji.specific.*;
import com.google.common.base.Objects;

<if (tweaks.GEN_COMMENTS && context.DocStringLines)>
<_docString(context.DocStringLines)>
<endif>
@SuppressWarnings("all")
public class <context.TypeName> extends SpecificRecordBase implements SpecificRecord<if (context.HasResponseStatus)>, HasResponseStatus<endif><if (context.HasMobileRequestHead)>, HasMobileRequestHead<endif> {
    private static final long serialVersionUID = 1L;

    public static final Schema SCHEMA = Schema.parse("<context.EscapedSchemaText>");

    @Override
    public Schema getSchema() { return SCHEMA; }

    <if(context.Fields)>
    <_structbody(context)>
    <endif>

    <_get(context)>

    <_put(context)>

    <if(context.Fields)>
    <_equals(context)>

    <_hashCode(context)>

    <_toString(context)>
    <endif>
}<\n>
>>

intEnum(context, tweaks, global) ::= <<
<! ================================================================================== !>
<! =                                                                                = !>
<! = int based enum definition                                                      = !>
<! =                                                                                = !>
<! = called from the generator to render a new enum java source file.               = !>
<! =                                                                                = !>
<! ================================================================================== !>
package <context.Namespace>;

<if (tweaks.GEN_COMMENTS && context.DocStringLines)>
<_docString(context.DocStringLines)>
<endif>
public enum <context.TypeName> {

    <context.Fields : { field|<_enumElement(field)>}; separator=",\n">;

    private final int value;

    <context.TypeName>(int value) {
        this.value = value;
    }

    <if (tweaks.GEN_COMMENTS)>
    /**
     * Get the integer value of this enum value, as defined in the Baiji IDL.
     */
    <endif>
    public int getValue() {
        return value;
    }

    <if (tweaks.GEN_COMMENTS)>
    /**
     * Get the integer value of this enum value, as defined in the Baiji IDL.
     */
    <endif>
    public static <context.TypeName> findByValue(int value) {
        switch (value) {
            <context.Fields : { field|<_enumFindByValueElement(field)>}; separator="\n">
            default:
                return null;
        }
    }
}<\n>
>>

_docString(lines) ::= <<
/**
 * <lines: {line|<line>}; separator="\n * ">
 */
>>

_enumFindByValueElement(field) ::= <<
case <field.Value>:
    return <field.Name>;
>>

_enumElement(field) ::= <<
<if (tweaks.GEN_COMMENTS && field.DocStringLines)>
<_docString(field.DocStringLines)>
<endif>
<field.Name><if(field.Value)>(<field.Value>)<endif>
>>

_method(method) ::= <<
<if (tweaks.GEN_COMMENTS && method.DocStringLines)>
<_docString(method.DocStringLines)>
<endif>
<method.ReturnType> <method.CodeName>(<if(method.ArgumentType)><method.ArgumentType> <method.ArgumentName><endif>) throws Exception;
>>

_params(parameters) ::= <<
<if(parameters)>(
    <parameters: {param |<_param(param)>}; separator=",\n">
)<else>()<endif>
>>

_param(param) ::= <<
<param.GenType.TypeName> <param.CodeName>
>>

_get(structContext) ::= <<
// Used by DatumWriter. Applications should not call.
public java.lang.Object get(int fieldPos) {
    switch (fieldPos) {
        <structContext.Fields : {field | <_getField(field, i0)>}; separator="\n">
        default: throw new BaijiRuntimeException("Bad index " + fieldPos + " in get()");
    }
}
>>

_getField(fieldContext, i0) ::= <<
case <i0>: return this.<fieldContext.CodeName>;
>>

_put(structContext) ::= <<
// Used by DatumReader. Applications should not call.
@SuppressWarnings(value="unchecked")
public void put(int fieldPos, java.lang.Object fieldValue) {
    switch (fieldPos) {
        <structContext.Fields : {field | <_putField(field, i0)>}; separator="\n">
        default: throw new BaijiRuntimeException("Bad index " + fieldPos + " in put()");
    }
}
>>

_putField(fieldContext, i0) ::= <<
case <i0>: this.<fieldContext.CodeName> = (<fieldContext.GenType.TypeName>)fieldValue; break;
>>

_toString(context) ::= <<
@Override
public String toString() {
    return Objects.toStringHelper(this)
        <context.Fields : { field |<_toStringField(field)>}; separator="\n">
        .toString();
}
>>

_toStringField(field) ::= <<
.add("<field.CodeName>", <field.CodeName>)
>>

_equals(context) ::= <<
@Override
public boolean equals(Object obj) {
    if (obj == null) return false;
    if (getClass() != obj.getClass()) return false;

    final <context.TypeName> other = (<context.TypeName>)obj;
    return 
        <context.Fields : { field |<_equalsField(field)>}; separator=" &&\n">;
}
>>

_equalsField(field) ::= <<
<if(field.GenType.IsBinary)>Arrays.equals(this.<field.CodeName>, other.<field.CodeName>)<else>Objects.equal(this.<field.CodeName>, other.<field.CodeName>)<endif>
>>

_hashCode(context) ::= <<
@Override
public int hashCode() {
    int result = 1;

    <context.Fields : { field |<_hashCodeField(field)>}; separator="\n">

    return result;
}
>>

_hashCodeField(field) ::= <<
result = 31 * result + (this.<field.CodeName> == null ? 0 : <if(field.GenType.IsBinary)>Arrays.hashCode(this.<field.CodeName>));<else>this.<field.CodeName>.hashCode());<endif>
>>
