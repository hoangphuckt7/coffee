// ignore_for_file: non_constant_identifier_names

import 'package:bbc_order_mobile/models/common/base_model.dart';
import 'package:bbc_order_mobile/models/order/order_detail_model.dart';
import 'package:json_annotation/json_annotation.dart';

part 'order_create_model.g.dart';

@JsonSerializable()
class OrderCreateModel {
  String? tableId;
  BaseModel? table;
  String? floorId;
  BaseModel? floor;
  List<OrderDetailModel>? orderDetail;

  OrderCreateModel(
    this.tableId,
    this.table,
    this.floorId,
    this.floor,
    this.orderDetail,
  );
}
