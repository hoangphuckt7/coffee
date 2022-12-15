// ignore_for_file: must_be_immutable
import 'dart:convert';
import 'dart:developer';

import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:orderr_app/models/order/detail_dct_model.dart';
import 'package:orderr_app/models/order/order_detail_model.dart';
import 'package:orderr_app/models/order/order_model.dart';
import 'package:orderr_app/repositories/item_repo.dart';
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
    List<OrderDetailModel> details = order.orderDetails ?? <OrderDetailModel>[];
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
            const SizedBox(height: 5),
            Column(
              children: List.generate(details.length, (i) {
                return _detail(context, details[i], i);
              }),
            ),
          ],
        ),
      ),
    );
  }

  Widget _detail(BuildContext context, OrderDetailModel detail, int i) {
    var img = Image.asset('images/img-not-found.png');
    if (detail.item?.images?.first != null) {
      img = Image.network(ItemRepo.getImg(detail.item?.images?.first));
    }
    return Column(
      children: [
        const Divider(color: MColor.primaryBlack, thickness: 2),
        Padding(
          padding: const EdgeInsets.all(5),
          child: Row(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Expanded(flex: 2, child: img),
              const SizedBox(width: 10),
              Expanded(
                flex: 3,
                child: Column(
                  children: [
                    _lineInfo('Tên món', detail.item?.name ?? ''),
                    const SizedBox(height: 10),
                    _lineInfo('Số lượng', detail.quantity),
                    const SizedBox(height: 10),
                    Column(
                      children: List.generate(
                        detail.listDescription!.length,
                        (index) {
                          var desc = detail.listDescription![index];
                          return _description(context, desc!, index + 1);
                        },
                      ),
                    ),
                  ],
                ),
              ),
            ],
          ),
        ),
      ],
    );
  }

  _lineInfo(String title, dynamic value) {
    return Row(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Text('$title:', style: titleStyle),
        const SizedBox(width: 10),
        Expanded(child: Text('$value'))
      ],
    );
  }

  Widget _description(BuildContext context, DetailDctModel? model, int index) {
    bool isShowSugarIce = !(model?.Sugar == 100 && model?.Ice == 100);
    bool isShowAll =
        !((model?.Note == null || model?.Note == '') && !isShowSugarIce);
    return Visibility(
      visible: isShowAll,
      child: Padding(
        padding: const EdgeInsets.all(2.5),
        child: Column(
          // spacing: 5,
          // direction: Axis.vertical,
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            const Divider(color: MColor.primaryBlack, thickness: 1),
            const SizedBox(height: 5),
            _lineInfo('Ghi chú #$index', model?.Note ?? ''),
            const SizedBox(height: 5),
            _lineInfo('Đường/Đá', _getSugarIceStr(model)),
          ],
        ),
      ),
    );
  }

  String _getSugarIceStr(DetailDctModel? model) {
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
    return '';
  }
}
