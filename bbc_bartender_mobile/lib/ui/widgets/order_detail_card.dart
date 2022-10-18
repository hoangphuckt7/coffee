import 'dart:convert';
import 'dart:developer';

import 'package:bbc_bartender_mobile/models/item/item_model.dart';
import 'package:bbc_bartender_mobile/models/order/order_detail_model.dart';
import 'package:bbc_bartender_mobile/repositories/item_repo.dart';
import 'package:bbc_bartender_mobile/ui/widgets/card_custom.dart';
import 'package:bbc_bartender_mobile/ui/widgets/line_info.dart';
import 'package:flutter/material.dart';

class OrderDetailCard extends StatelessWidget {
  final OrderDetailModel model;

  const OrderDetailCard({
    super.key,
    required this.model,
  });
  @override
  Widget build(BuildContext context) {
    bool check = false;

    var img = Image.asset('assets/images/img-not-found.png');
    if (model.item?.images?.first != null) {
      img = Image.network(ItemRepo.getImg(model.item?.images?.first));
    }
    return CardCustom(
      shadow: 20,
      padding: const EdgeInsets.all(15),
      child: Row(
        children: [
          SizedBox(
            width: 150,
            child: img,
          ),
          const SizedBox(width: 10),
          Expanded(
            child: Column(
              children: [
                LineInfo(
                  title: 'Tên món',
                  content: model.item?.name,
                ),
                const SizedBox(height: 10),
                LineInfo(
                  title: 'Số lượng',
                  content: model.quantity,
                ),
                const SizedBox(height: 10),
                LineInfo(
                  title: 'Ghi chú',
                  content: model.description,
                  errMsg: 'Không có',
                ),
              ],
            ),
          ),
          Checkbox(
            shape:
                RoundedRectangleBorder(borderRadius: BorderRadius.circular(10)),
            value: check,
            onChanged: (value) {
              check = !check;
            },
          )
        ],
      ),
    );
  }
}
