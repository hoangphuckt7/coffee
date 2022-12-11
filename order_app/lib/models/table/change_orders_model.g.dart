// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'change_orders_model.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

ChangeOrdersModel _$ChangeOrdersModelFromJson(Map<String, dynamic> json) =>
    ChangeOrdersModel(
      (json['orderIds'] as List<dynamic>).map((e) => e as String?).toList(),
      json['newTableId'] as String,
    );

Map<String, dynamic> _$ChangeOrdersModelToJson(ChangeOrdersModel instance) =>
    <String, dynamic>{
      'orderIds': instance.orderIds,
      'newTableId': instance.newTableId,
    };
