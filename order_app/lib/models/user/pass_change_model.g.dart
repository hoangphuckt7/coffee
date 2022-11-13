// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'pass_change_model.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

PassChangeModel _$PassChangeModelFromJson(Map<String, dynamic> json) =>
    PassChangeModel(
      json['oldPassword'] as String?,
      json['newPassword'] as String?,
      json['newPasswordConfirm'] as String?,
    );

Map<String, dynamic> _$PassChangeModelToJson(PassChangeModel instance) =>
    <String, dynamic>{
      'oldPassword': instance.oldPassword,
      'newPassword': instance.newPassword,
      'newPasswordConfirm': instance.newPasswordConfirm,
    };
