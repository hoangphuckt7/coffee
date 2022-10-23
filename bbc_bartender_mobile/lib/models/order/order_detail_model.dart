import 'dart:convert';

import 'package:bbc_bartender_mobile/models/item/item_model.dart';
import 'package:bbc_bartender_mobile/models/order/detail_dct_model.dart';
import 'package:json_annotation/json_annotation.dart';

part 'order_detail_model.g.dart';

@JsonSerializable()
class OrderDetailModel {
  int? uniqueKey;
  final DateTime? dateUpdated;
  int? quantity;
  final int? finalQuantity;
  final String? missingReason;
  final double? price;
  final String? description;
  DetailDctModel? dctModel;
  final String? itemId;
  ItemModel? item;
  final String? orderId;

  OrderDetailModel(
    this.uniqueKey,
    this.dateUpdated,
    this.quantity,
    this.finalQuantity,
    this.missingReason,
    this.price,
    this.description,
    this.itemId,
    this.item,
    this.orderId,
  );

  factory OrderDetailModel.fromJson(Map<String, dynamic> json) =>
      _$OrderDetailModelFromJson(json);

  Map<String, dynamic> toJson() => _$OrderDetailModelToJson(this);

  factory OrderDetailModel.clone(data) {
    return OrderDetailModel.fromJson(jsonDecode(jsonEncode(data)));
  }
}
