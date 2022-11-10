// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'order_detail_create_model.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

OrderDetailCreateModel _$OrderDetailCreateModelFromJson(
        Map<String, dynamic> json) =>
    OrderDetailCreateModel(
      json['itemId'] as String?,
      json['item'] == null
          ? null
          : ItemModel.fromJson(json['item'] as Map<String, dynamic>),
      json['quantity'] as int,
      json['description'] as String?,
      (json['listDct'] as List<dynamic>?)
          ?.map((e) => DetailDctModel.fromJson(e as Map<String, dynamic>))
          .toList(),
    );

Map<String, dynamic> _$OrderDetailCreateModelToJson(
        OrderDetailCreateModel instance) =>
    <String, dynamic>{
      'itemId': instance.itemId,
      'item': instance.item,
      'quantity': instance.quantity,
      'listDct': instance.listDct,
      'description': instance.description,
    };
