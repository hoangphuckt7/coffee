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
      json['itemId'] as String?,
      json['item'] == null
          ? null
          : ItemModel.fromJson(json['item'] as Map<String, dynamic>),
      json['orderId'] as String?,
    )..dctModel = json['dctModel'] == null
        ? null
        : DetailDctModel.fromJson(json['dctModel'] as Map<String, dynamic>);

Map<String, dynamic> _$OrderDetailModelToJson(OrderDetailModel instance) =>
    <String, dynamic>{
      'dateUpdated': instance.dateUpdated?.toIso8601String(),
      'quantity': instance.quantity,
      'finalQuantity': instance.finalQuantity,
      'missingReason': instance.missingReason,
      'price': instance.price,
      'description': instance.description,
      'dctModel': instance.dctModel,
      'itemId': instance.itemId,
      'item': instance.item,
      'orderId': instance.orderId,
    };
