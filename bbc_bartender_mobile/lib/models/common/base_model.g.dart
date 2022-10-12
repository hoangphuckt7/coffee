// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'base_model.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

BaseModel _$BaseModelFromJson(Map<String, dynamic> json) => BaseModel(
      json['id'] as String?,
      json['description'] as String?,
      json['dateCreated'] == null
          ? null
          : DateTime.parse(json['dateCreated'] as String),
      json['dateUpdated'] == null
          ? null
          : DateTime.parse(json['dateUpdated'] as String),
      json['isDeleted'] as bool?,
    );

Map<String, dynamic> _$BaseModelToJson(BaseModel instance) => <String, dynamic>{
      'id': instance.id,
      'description': instance.description,
      'dateCreated': instance.dateCreated?.toIso8601String(),
      'dateUpdated': instance.dateUpdated?.toIso8601String(),
      'isDeleted': instance.isDeleted,
    };
