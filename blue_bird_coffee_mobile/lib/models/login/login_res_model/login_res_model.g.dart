// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'login_res_model.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

LoginResModel _$LoginResModelFromJson(Map<String, dynamic> json) =>
    LoginResModel(
      json['fullName'] as String?,
      json['token'] as String?,
      json['role'] as String?,
    );

Map<String, dynamic> _$LoginResModelToJson(LoginResModel instance) =>
    <String, dynamic>{
      'fullName': instance.fullName,
      'token': instance.token,
      'role': instance.role,
    };
