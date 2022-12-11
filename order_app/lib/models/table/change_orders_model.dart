import 'package:json_annotation/json_annotation.dart';

part 'change_orders_model.g.dart';

@JsonSerializable()
class ChangeOrdersModel {
  final List<String?> orderIds;
  final String newTableId;

  ChangeOrdersModel(this.orderIds, this.newTableId);

  factory ChangeOrdersModel.fromJson(Map<String, dynamic> json) =>
      _$ChangeOrdersModelFromJson(json);

  Map<String, dynamic> toJson() => _$ChangeOrdersModelToJson(this);
}
