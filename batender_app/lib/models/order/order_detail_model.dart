import 'dart:convert';

import 'package:bartender_app/models/item/item_model.dart';
import 'package:bartender_app/models/order/detail_dct_model.dart';
import 'package:json_annotation/json_annotation.dart';

part 'order_detail_model.g.dart';

@JsonSerializable()
class OrderDetailModel {
  final DateTime? dateUpdated;
  int? quantity;
  final int? finalQuantity;
  final String? missingReason;
  final double? price;
  final String? description;
  List<DetailDctModel?>? listDescription = <DetailDctModel>[];
  final String? itemId;
  ItemModel? item;
  final String? orderId;

  OrderDetailModel(
    this.dateUpdated,
    this.quantity,
    this.finalQuantity,
    this.missingReason,
    this.price,
    this.description,
    this.listDescription,
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
