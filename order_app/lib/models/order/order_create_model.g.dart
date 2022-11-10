// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'order_create_model.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

OrderCreateModel _$OrderCreateModelFromJson(Map<String, dynamic> json) =>
    OrderCreateModel(
      json['tableId'] as String?,
      json['table'] == null
          ? null
          : TableModel.fromJson(json['table'] as Map<String, dynamic>),
      json['floorId'] as String?,
      json['floor'] == null
          ? null
          : BaseModel.fromJson(json['floor'] as Map<String, dynamic>),
      (json['orderDetail'] as List<dynamic>?)
          ?.map(
              (e) => OrderDetailCreateModel.fromJson(e as Map<String, dynamic>))
          .toList(),
    );

Map<String, dynamic> _$OrderCreateModelToJson(OrderCreateModel instance) =>
    <String, dynamic>{
      'tableId': instance.tableId,
      'table': instance.table,
      'floorId': instance.floorId,
      'floor': instance.floor,
      'orderDetail': instance.orderDetail,
    };
