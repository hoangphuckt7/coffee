import 'package:bbc_bartender_mobile/models/common/base_model.dart';
import 'package:bbc_bartender_mobile/models/order/order_detail_model.dart';
import 'package:json_annotation/json_annotation.dart';

part 'order_model.g.dart';

@JsonSerializable()
class OrderModel {
  final String? id;
  final String? description;
  final DateTime? dateCreated;
  final DateTime? dateUpdated;
  final bool? isDeleted;
  final bool? isCompleted;
  final bool? isCheckout;
  final bool? isRejected;
  final bool? isMissing;
  final String? rejectedReason;
  final String? tableId;
  final BaseModel? table;
  final String? employeeId;
  final String? userRejectedId;
  final int? orderNumber;
  final List<OrderDetailModel> orderDetails;

  OrderModel(
    this.id,
    this.description,
    this.dateCreated,
    this.dateUpdated,
    this.isDeleted,
    this.isCompleted,
    this.isCheckout,
    this.isRejected,
    this.isMissing,
    this.rejectedReason,
    this.tableId,
    this.table,
    this.employeeId,
    this.userRejectedId,
    this.orderNumber,
    this.orderDetails,
  );

  factory OrderModel.fromJson(Map<String, dynamic> json) =>
      _$OrderModelFromJson(json);

  Map<String, dynamic> toJson() => _$OrderModelToJson(this);
}
