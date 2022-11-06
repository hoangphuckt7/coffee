// ignore_for_file: non_constant_identifier_names

import 'dart:convert';

import 'package:bbc_order_mobile/models/common/base_model.dart';
import 'package:bbc_order_mobile/models/item/item_model.dart';
import 'package:bbc_order_mobile/models/order/detail_dct_model.dart';
import 'package:bbc_order_mobile/models/order/order_detail_model.dart';
import 'package:json_annotation/json_annotation.dart';

part 'order_detail_create_model.g.dart';

@JsonSerializable()
class OrderDetailCreateModel {
  String? itemId;
  ItemModel? item;
  int quantity = 0;
  List<DetailDctModel>? listDct;
  String? description;

  OrderDetailCreateModel(
    this.itemId,
    this.item,
    this.quantity,
    this.description,
    this.listDct,
  );
}
