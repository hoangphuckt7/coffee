// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'bill_model.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

BillModel _$BillModelFromJson(Map<String, dynamic> json) => BillModel(
      json['id'] as String?,
      json['description'] as String?,
      json['dateCreated'] == null
          ? null
          : DateTime.parse(json['dateCreated'] as String),
      json['dateUpdated'] == null
          ? null
          : DateTime.parse(json['dateUpdated'] as String),
      json['isDeleted'] as bool?,
      json['itemMissingReason'] as String?,
      json['coupon'] as String?,
      (json['discount'] as num?)?.toDouble(),
      json['isTakeAway'] as bool?,
      json['CasherId'] as String?,
      json['CustomerId'] as String?,
    );

Map<String, dynamic> _$BillModelToJson(BillModel instance) => <String, dynamic>{
      'id': instance.id,
      'description': instance.description,
      'dateCreated': instance.dateCreated?.toIso8601String(),
      'dateUpdated': instance.dateUpdated?.toIso8601String(),
      'isDeleted': instance.isDeleted,
      'itemMissingReason': instance.itemMissingReason,
      'coupon': instance.coupon,
      'discount': instance.discount,
      'isTakeAway': instance.isTakeAway,
      'CasherId': instance.CasherId,
      'CustomerId': instance.CustomerId,
    };
