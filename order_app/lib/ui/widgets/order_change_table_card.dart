// ignore_for_file: must_be_immutable

import 'dart:convert';
import 'dart:developer';

import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:orderr_app/models/order/order_model.dart';
import 'package:orderr_app/ui/widgets/card_custom.dart';
import 'package:orderr_app/utils/function_common.dart';
import 'package:orderr_app/utils/ui_setting.dart';

class OrderChangeTableCard extends StatelessWidget {
  final OrderModel order;
  final double padding;
  final List<String?>? lstSelected;
  void Function()? onTap;
  OrderChangeTableCard({
    super.key,
    required this.order,
    this.padding = 15,
    this.lstSelected,
    this.onTap,
  });

  TextStyle titleStyle = const TextStyle(fontWeight: FontWeight.bold);

  _getHighLight() {
    if (lstSelected != null && lstSelected!.isNotEmpty) {
      if (lstSelected!.contains(order.id)) {
        return MColor.primaryGreen;
      }
    }
    return MColor.white;
  }

  @override
  Widget build(BuildContext context) {
    log('${jsonEncode(order.orderDetails)}');
    return InkWell(
      onTap: onTap,
      child: CardCustom(
        shadow: 10,
        borderSide: BorderSide(color: _getHighLight(), width: 2),
        padding: EdgeInsets.all(padding),
        child: Column(
          children: [
            Row(
              children: [
                Expanded(
                  child: _lineInfo(
                    "Order",
                    Fn.convertOrderNumber(order.orderNumber),
                  ),
                ),
                Expanded(
                  child: _lineInfo(
                    "Giờ vào",
                    Fn.formatDate(order.dateCreated, DateFormat.Hm()),
                  ),
                ),
                Expanded(
                  child: _lineInfo("Số món", order.orderDetails?.length),
                ),
              ],
            ),
            const Padding(
              padding: EdgeInsets.symmetric(vertical: 10),
              child: Divider(color: MColor.primaryBlack, thickness: 1),
            ),
          ],
        ),
      ),
    );
  }

  _lineInfo(String title, dynamic value) {
    return Row(
      children: [
        Expanded(child: Text('$title: ', style: titleStyle)),
        Expanded(child: Text('$value')),
      ],
    );
  }
}
