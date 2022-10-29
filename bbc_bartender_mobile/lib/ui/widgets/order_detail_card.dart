import 'dart:convert';
import 'dart:developer';

import 'package:bbc_bartender_mobile/models/order/detail_dct_model.dart';
import 'package:bbc_bartender_mobile/models/order/order_detail_model.dart';
import 'package:bbc_bartender_mobile/repositories/item_repo.dart';
import 'package:bbc_bartender_mobile/ui/widgets/card_custom.dart';
import 'package:bbc_bartender_mobile/ui/widgets/line_info.dart';
import 'package:bbc_bartender_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';

class OrderDetailCard extends StatelessWidget {
  final OrderDetailModel model;
  final List<String>? itemCheck;
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
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          SizedBox(
            width: 150,
            child: Column(
              mainAxisAlignment: MainAxisAlignment.start,
              children: [
                img,
              ],
            ),
          ),
          const SizedBox(width: 10),
          Expanded(
            child: SizedBox(
              child: Column(
                mainAxisAlignment: MainAxisAlignment.center,
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
                  SizedBox(
                    child: Column(
                      children:
                          List.generate(model.listDescription!.length, (index) {
                        var desc = model.listDescription![index];
                        return _description(context, desc!, index + 1);
                      }),
                    ),
                  ),
                ],
              ),
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
                value: itemCheck?.any((x) => x == model.itemId),
                onChanged: onItemCheckChanged,
              ),
            ),
          ),
        ],
      ),
    );
  }

  Widget _description(BuildContext context, DetailDctModel model, int index) {
    bool isShowSugarIce = !(model.Sugar == 100 && model.Ice == 100);
    bool isShowAll =
        !((model.Note == null || model.Note == '') && !isShowSugarIce);
    return Visibility(
      visible: isShowAll,
      child: Column(
        children: [
          const SizedBox(height: 5),
          const Divider(color: MColor.primaryBlack, thickness: .2),
          const SizedBox(height: 5),
          LineInfo(
            title: 'Ghi chú #$index',
            content: model.Note,
            errMsg: 'Không',
          ),
          Visibility(
            visible: isShowSugarIce,
            child: Column(
              children: [
                const SizedBox(height: 10),
                LineInfo(
                  title: '',
                  titleColor: MColor.danger,
                  content: _getSugarIceStr(model),
                  contentColor: MColor.danger,
                  isBoldContent: true,
                  errMsg: 'Không',
                ),
              ],
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
