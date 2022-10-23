import 'dart:convert';
import 'dart:developer';

import 'package:bbc_bartender_mobile/models/order/detail_dct_model.dart';
import 'package:bbc_bartender_mobile/models/order/order_detail_model.dart';
import 'package:bbc_bartender_mobile/repositories/item_repo.dart';
import 'package:bbc_bartender_mobile/ui/widgets/card_custom.dart';
import 'package:bbc_bartender_mobile/ui/widgets/line_info.dart';
import 'package:bbc_bartender_mobile/utils/color_custom.dart';
import 'package:bbc_bartender_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';

class OrderDetailCard extends StatelessWidget {
  final OrderDetailModel model;
  final List<int>? itemCheck;
  final Function(bool?)? onItemCheckChanged;
  final bool? showCheckItem;
  const OrderDetailCard({
    super.key,
    required this.model,
    this.itemCheck,
    this.onItemCheckChanged,
    this.showCheckItem = true,
  });
  @override
  Widget build(BuildContext context) {
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
                  content: model.dctModel?.Note,
                  errMsg: 'Không có',
                ),
                Visibility(
                  visible: !(model.dctModel?.Sugar == 100 &&
                      model.dctModel?.Ice == 100),
                  child: Column(
                    children: [
                      const SizedBox(height: 10),
                      LineInfo(
                        title: 'Tỉ lệ',
                        titleColor: MColor.danger,
                        content: _getSugarIceStr(model.dctModel),
                        contentColor: MColor.danger,
                        isBoldContent: true,
                        errMsg: 'Không có',
                      ),
                    ],
                  ),
                ),
              ],
            ),
          ),
          Visibility(
            visible: showCheckItem!,
            child: Transform.scale(
              scale: 1.5,
              child: Checkbox(
                checkColor: Colors.white,
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(50),
                ),
                fillColor:
                    MaterialStateProperty.all<Color>(MColor.primaryGreen),
                value: itemCheck?.any((x) => x == model.uniqueKey),
                onChanged: onItemCheckChanged,
              ),
            ),
          ),
        ],
      ),
    );
  }

  String? _getSugarIceStr(DetailDctModel? model) {
    if (model != null) {
      if (model.Sugar != null && model.Ice != null) {
        if (model.Sugar! != 100 && model.Ice! != 100) {
          return 'Đường: ${model.Sugar} | Đá: ${model.Ice}';
        } else {
          if (model.Sugar! != 100) {
            return 'Đường: ${model.Sugar}';
          }
          if (model.Ice! != 100) {
            return 'Đá: ${model.Ice}';
          }
        }
      }
    }
    return null;
  }
}
