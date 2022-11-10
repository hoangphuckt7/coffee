// ignore_for_file: non_constant_identifier_names

import 'package:orderr_app/models/common/base_model.dart';
import 'package:orderr_app/models/order/order_detail_create_model.dart';
import 'package:orderr_app/models/table/table_model.dart';
import 'package:json_annotation/json_annotation.dart';

part 'order_create_model.g.dart';

@JsonSerializable()
class OrderCreateModel {
  String? tableId;
  TableModel? table;
  String? floorId;
  BaseModel? floor;
  List<OrderDetailCreateModel>? orderDetail;

  OrderCreateModel(
    this.tableId,
    this.table,
    this.floorId,
    this.floor,
    this.orderDetail,
  );

  factory OrderCreateModel.fromJson(Map<String, dynamic> json) =>
      _$OrderCreateModelFromJson(json);

  Map<String, dynamic> toJson() => _$OrderCreateModelToJson(this);
}
