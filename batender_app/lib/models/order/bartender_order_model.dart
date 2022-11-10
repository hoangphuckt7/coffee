import 'package:bartender_app/models/order/order_model.dart';
import 'package:json_annotation/json_annotation.dart';

part 'bartender_order_model.g.dart';

@JsonSerializable()
class BartenderOrderModel {
  final List<OrderModel> listOrderNew;
  final List<OrderModel> listOrderCompleted;

  BartenderOrderModel(
    this.listOrderNew,
    this.listOrderCompleted,
  );

  factory BartenderOrderModel.fromJson(Map<String, dynamic> json) =>
      _$BartenderOrderModelFromJson(json);

  Map<String, dynamic> toJson() => _$BartenderOrderModelToJson(this);
}
