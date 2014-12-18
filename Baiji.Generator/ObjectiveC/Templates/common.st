struct(context, tweaks, global) ::= <<
<! ================================================================================== !>
<! =                                                                                = !>
<! = struct definition                                                              = !>
<! =                                                                                = !>
<! = called from the generator to render a new struct OC.m source file.             = !>
<! =                                                                                = !>
<! ================================================================================== !>

#import "<context.TypeName>.h"

<if (tweaks.GEN_COMMENTS && context.DocStringLines)>
<_docString(context.DocStringLines)>
<endif>

@implementation <context.TypeName>

<_schema(context)>

<if(context.Fields)>
<_initMain(context)>
<endif>

<if(context.Fields)>
<_fieldAtIndex(context)>
<endif>

<if(context.Fields)>
<_setObjectAtIndex(context)>
<endif>

#pragma override NSObject methods

<if(context.Fields)>
<_isEqual(context)>

<_hash(context)>

<if (!tweaks.AUTO_RELEASE)>
<_dealloc(context)>
<endif>
<endif>

@end
>>

structHeader(context, tweaks, global) ::= <<
<! ================================================================================== !>
<! =                                                                                = !>
<! = struct definition                                                              = !>
<! =                                                                                = !>
<! = called from the generator to render a new struct OC.h source file.             = !>
<! =                                                                                = !>
<! ================================================================================== !>
#import \<Foundation/Foundation.h\>
#import \<Baiji/Baiji.h\>
<_includes(context)>
<if (tweaks.GEN_COMMENTS && context.DocStringLines)>
<_docString(context.DocStringLines)>
<endif>

@interface <context.TypeName> : BJMutableSpecificRecord<_protocol(context)>

<if(context.Fields)>
<_headerProperty(context)>
<endif>

<if(context.Fields)>
<_initHeader(context)>
<endif>

@end
>>

_protocol(context) ::= <<
<if (context.HasResponseStatus&&context.HasMobileRequestHead)>\<BJHasResponseStatus, BJHasMobileRequestHead\><endif><if (context.HasResponseStatus&&!context.HasMobileRequestHead)>\<BJHasResponseStatus\><endif><if (!context.HasResponseStatus&&context.HasMobileRequestHead)>\<BJHasMobileRequestHead\><endif>
>>

_includes(context) ::= <<
<context.Fields : { field |<if (field.GenType.isStruct||field.GenType.isEnum)><_class(field)><endif>}; separator="">
>>

_class(field) ::= <<
@class <field.GenType.TypeName>;<\n>
>>

_headerProperty(context) ::= <<
<context.Fields : { field |<_property(field)>}; separator="\n">
>>

_property(field) ::= <<
< if (tweaks.GEN_COMMNETS && field.DocStringLines)>
<_docString(field.DocStringLines)>
<endif>
@property (nonatomic, readwrite, <if (tweaks.AUTO_RELEASE)>strong<else>retain<endif>) <field.GenType.TypeName> *<field.CodeName>;
>>

enumHeader(context, tweaks, global) ::= <<
<! ================================================================================== !>
<! =                                                                                = !>
<! = enum definition                                                              = !>
<! =                                                                                = !>
<! = called from the generator to render a new enum OC.h source file.             = !>
<! =                                                                                = !>
<! ================================================================================== !>
#import \<Foundation/Foundation.h\>
#import \<Baiji/Baiji.h\>

<if (tweaks.GEN_COMMENTS && context.DocStringLines)>
<_docString(context.DocStringLines)>
<endif>

enum {
	<context.Fields : { field | <context.TypeName><field.Name>,}; separator="\n">
};

@interface <context.TypeName> : BJSpecificEnum

@end
>>

intEnum(context, tweaks, global) ::= <<
<! ================================================================================== !>
<! =                                                                                = !>
<! = int based enum definition                                                      = !>
<! =                                                                                = !>
<! = called from the generator to render a new enum OC.m source file.               = !>
<! =                                                                                = !>
<! ================================================================================== !>
#import "<context.TypeName>.h"

<if (tweaks.GEN_COMMENTS && context.DocStringLines)>
<_docString(context.DocStringLines)>
<endif>

NSString *const <context.TypeName>Names[] = {
	<context.Fields : { field | <_enumElement(field)>, }; separator="\n">
};

@implementation <context.TypeName>

- (NSString *)name {
	return <context.TypeName>Names[self.value];
}

+ (NSUInteger)ordinalForName:(NSString *)name {
	<context.Fields : { field | <_ordinalForName(context, field)>}; separator="\n">
	return -1;
}

#pragma override NSObject methods

<_isEnumEqual(context)>

@end
>>

_docString(lines) ::= <<
/**
 * <lines: {line|<line>}; separator="\n * ">
 */
>>

_ordinalForName(context, field) ::= <<
if([<context.TypeName>Names[<context.TypeName><field.Name>] isEqual:name])
	return <context.TypeName>field.Name;
>>

_enumElement(field) ::= <<
[<context.TypeName><field.Name>] = @"<field.Name>"
>>

_isEnumEqual(context) ::= <<
- (BOOL)isEqual:(id)object {
	if (object == nil)
		return NO;
	if (![object isKindOfClass:[<context.TypeName> class]])
		return NO;
	<context.TypeName> *that = (<context.TypeName> *)object;
	if (self.value == [that value])
		return YES;
	return NO;
}
>>

_initHeader(context) ::= <<
- (id)initWith<context.Fields : { field |<_initProperty(field)>}; separator="\n\t\t\t">;
>>

_initProperty(field) ::= <<
<field.CodeName>:(<field.GenType.TypeName> *)<field.CodeName>
>>

_initMain(context) ::= <<
- (id)initWith<context.Fields : { field |<_initProperty(field)>}; separator="\n\t\t\t">{
	self = [self init];
	if (self) {
		<context.Fields : { field |<_initAssign(field)>}; separator="\n">
	}
	return self;
}
>>

_initAssign(field) :: <<
self.<field.CodeName> = <field.CodeName>;
>>

_schema(context) ::= <<
- (BJSchema *)schema {
	static BJSchema *__schema = nil;
	static dispatch_once_t onceToken;
	dispatch_once (&onceToken, ^{
	<if (tweaks.AUTO_RELEASE)>
		__schema = [BJSchema parse:@"<context.EscapedSchemaText>"];
	<else>
		__schema = [[BJSchema parse:@"<context.EscapedSchemaText>"] retain];
	<endif>
	});
	return __schema;
}
>>

_fieldAtIndex(structContext) ::= <<
- (id)fieldAtIndex:(int)fieldPos {
	switch(fieldPos) {
		<structContext.Fields : {field | <_getField(field, i0)>}; separator="\n">
		default:
			@throw [NSException exceptionWithName:BJRuntimeException
									reason:[NSString stringWithFormat:@"Bad index %d in fieldAtIndex:", fieldPos]
								   userInfo:nil];
	}
	return nil;
}
>>

_getField(fieldContext, i0) ::= <<
case <i0>: return self.<fieldContext.CodeName>;
>>

_setObjectAtIndex(structContext) ::= <<
- (void)setObject:(id)object atIndex:(int)fieldPos {
	switch(fieldPos) {
		<structContext.Fields : {field | <_setField(field, i0)>}; separator="\n">
		default:
			@throw [NSException exceptionWithName:BJRuntimeException
									reason:[NSString stringWithFormat:@"Bad index %d in setObject:atIndex:", fieldPos]
								userInfo: nil];
	}
}
>>

_setField(fieldContext, i0) ::= <<
case <i0>: self.<fieldContext.CodeName> = object; break;
>>

_isEqual(context) ::= <<
- (BOOL)isEqual:(id)object {
	if (object == nil)
		return NO;
	if ([self class] != [object class])
		return NO;

	<context.TypeName> *that = (<context.TypeName> *)object;
	return
		<context.Fields : {field | <_equalField(field)>}; separator=" &&\n">; 
}
>>

_equalField(field) ::= <<
[self.<field.CodeName> isEqual:[that <field.CodeName>]]
>>

_hash(context) ::= <<
- (NSUInteger)hash {
	NSUInteger result = 1;

	<context.Fields : {field | <_hashField(field)>}; separator="\n">

	return result;
}
>>

_hashField(field) ::= <<
result = 31 * result + (self.<field.CodeName> == nil ? 0 : [self.<field.CodeName> hash]);
>>

_dealloc(context) ::= <<
- (void)dealloc {
	<context.Fields : {field | <_deallocField(field)>}; separator="\n">
	[super dealloc];
}
>>

_deallocField(field) ::= <<
[self.<field.CodeName> release];
>>