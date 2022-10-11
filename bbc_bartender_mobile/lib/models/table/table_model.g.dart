// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'table_model.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

TableModel _$TableModelFromJson(Map<String, dynamic> json) => TableModel(
      json['id'] as String?,
      json['description'] as String?,
      json['currentOrder'] as int?,
      json['position'] as String?,
      json['size'] as String?,
      json['shape'] as String?,
      json['rotation'] as int?,
      json['floor'] == null
          ? null
          : FloorModel.fromJson(json['floor'] as Map<String, dynamic>),
    );

Map<String, dynamic> _$TableModelToJson(TableModel instance) =>
    <String, dynamic>{
      'id': instance.id,
      'description': instance.description,
      'currentOrder': instance.currentOrder,
      'position': instance.position,
      'size': instance.size,
      'shape': instance.shape,
      'rotation': instance.rotation,
      'floor': instance.floor,
    };
