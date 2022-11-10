// ignore_for_file: non_constant_identifier_names

import 'package:json_annotation/json_annotation.dart';

part 'bill_model.g.dart';

@JsonSerializable()
class BillModel {
  final String? id;
  final String? description;
  final DateTime? dateCreated;
  final DateTime? dateUpdated;
  final bool? isDeleted;
  final String? itemMissingReason;
  final String? coupon;
  final double? discount;
  final bool? isTakeAway;
  final String? CasherId;
  final String? CustomerId;

  BillModel(
    this.id,
    this.description,
    this.dateCreated,
    this.dateUpdated,
    this.isDeleted,
    this.itemMissingReason,
    this.coupon,
    this.discount,
    this.isTakeAway,
    this.CasherId,
    this.CustomerId,
  );

  factory BillModel.fromJson(Map<String, dynamic> json) =>
      _$BillModelFromJson(json);

  Map<String, dynamic> toJson() => _$BillModelToJson(this);
}
