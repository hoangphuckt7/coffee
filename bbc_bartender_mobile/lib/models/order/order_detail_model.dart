import 'package:json_annotation/json_annotation.dart';

part 'order_detail_model.g.dart';

@JsonSerializable()
class OrderDetailModel {
  final DateTime? dateUpdated;
  final int? quantity;
  final int? finalQuantity;
  final String? missingReason;
  final double? price;
  final String? description;
  final String? itemId;
  final String? orderId;

  OrderDetailModel(
    this.dateUpdated,
    this.quantity,
    this.finalQuantity,
    this.missingReason,
    this.price,
    this.description,
    this.itemId,
    this.orderId,
  );

  factory OrderDetailModel.fromJson(Map<String, dynamic> json) =>
      _$OrderDetailModelFromJson(json);

  Map<String, dynamic> toJson() => _$OrderDetailModelToJson(this);
}
