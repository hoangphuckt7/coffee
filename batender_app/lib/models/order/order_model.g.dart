// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'order_model.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

OrderModel _$OrderModelFromJson(Map<String, dynamic> json) => OrderModel(
      json['id'] as String?,
      json['description'] as String?,
      json['dateCreated'] == null
          ? null
          : DateTime.parse(json['dateCreated'] as String),
      json['dateUpdated'] == null
          ? null
          : DateTime.parse(json['dateUpdated'] as String),
      json['isDeleted'] as bool?,
      json['isCompleted'] as bool?,
      json['isCheckout'] as bool?,
      json['isRejected'] as bool?,
      json['isMissing'] as bool?,
      json['rejectedReason'] as String?,
      json['tableId'] as String?,
      json['table'] == null
          ? null
          : BaseModel.fromJson(json['table'] as Map<String, dynamic>),
      json['employeeId'] as String?,
      json['userRejectedId'] as String?,
      json['orderNumber'] as int?,
      (json['orderDetails'] as List<dynamic>?)
          ?.map((e) => OrderDetailModel.fromJson(e as Map<String, dynamic>))
          .toList(),
    );

Map<String, dynamic> _$OrderModelToJson(OrderModel instance) =>
    <String, dynamic>{
      'id': instance.id,
      'description': instance.description,
      'dateCreated': instance.dateCreated?.toIso8601String(),
      'dateUpdated': instance.dateUpdated?.toIso8601String(),
      'isDeleted': instance.isDeleted,
      'isCompleted': instance.isCompleted,
      'isCheckout': instance.isCheckout,
      'isRejected': instance.isRejected,
      'isMissing': instance.isMissing,
      'rejectedReason': instance.rejectedReason,
      'tableId': instance.tableId,
      'table': instance.table,
      'employeeId': instance.employeeId,
      'userRejectedId': instance.userRejectedId,
      'orderNumber': instance.orderNumber,
      'orderDetails': instance.orderDetails,
    };
