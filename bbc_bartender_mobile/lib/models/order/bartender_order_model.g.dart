// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'bartender_order_model.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

BartenderOrderModel _$BartenderOrderModelFromJson(Map<String, dynamic> json) =>
    BartenderOrderModel(
      (json['listOrderNew'] as List<dynamic>)
          .map((e) => OrderModel.fromJson(e as Map<String, dynamic>))
          .toList(),
      (json['listOrderCompleted'] as List<dynamic>)
          .map((e) => OrderModel.fromJson(e as Map<String, dynamic>))
          .toList(),
    );

Map<String, dynamic> _$BartenderOrderModelToJson(
        BartenderOrderModel instance) =>
    <String, dynamic>{
      'listOrderNew': instance.listOrderNew,
      'listOrderCompleted': instance.listOrderCompleted,
    };
