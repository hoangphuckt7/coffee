// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'order_detail_model.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

OrderDetailModel _$OrderDetailModelFromJson(Map<String, dynamic> json) =>
    OrderDetailModel(
      json['dateUpdated'] == null
          ? null
          : DateTime.parse(json['dateUpdated'] as String),
      json['quantity'] as int?,
      json['finalQuantity'] as int?,
      json['missingReason'] as String?,
      (json['price'] as num?)?.toDouble(),
      json['description'] as String?,
      (json['listDescription'] as List<dynamic>?)
          ?.map((e) => e == null
              ? null
              : DetailDctModel.fromJson(e as Map<String, dynamic>))
          .toList(),
      json['itemId'] as String?,
      json['item'] == null
          ? null
          : ItemModel.fromJson(json['item'] as Map<String, dynamic>),
      json['orderId'] as String?,
    );

Map<String, dynamic> _$OrderDetailModelToJson(OrderDetailModel instance) =>
    <String, dynamic>{
      'dateUpdated': instance.dateUpdated?.toIso8601String(),
      'quantity': instance.quantity,
      'finalQuantity': instance.finalQuantity,
      'missingReason': instance.missingReason,
      'price': instance.price,
      'description': instance.description,
      'listDescription': instance.listDescription,
      'itemId': instance.itemId,
      'item': instance.item,
      'orderId': instance.orderId,
    };
