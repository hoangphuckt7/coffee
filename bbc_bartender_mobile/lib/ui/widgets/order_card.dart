import 'package:bbc_bartender_mobile/models/order/order_model.dart';
import 'package:bbc_bartender_mobile/ui/widgets/card_custom.dart';
import 'package:bbc_bartender_mobile/ui/widgets/line_info.dart';
import 'package:bbc_bartender_mobile/utils/function_common.dart';
import 'package:bbc_bartender_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';

class OrderCard extends StatelessWidget {
  final OrderModel orderModel;
  final bool isSelected;
  final bool isPinned;
  const OrderCard({
    super.key,
    required this.orderModel,
    this.isSelected = false,
    this.isPinned = false,
  });

  @override
  Widget build(BuildContext context) {
    return CardCustom(
      shadow: 20,
      edgeInsets: const EdgeInsets.all(15),
      borderSide: BorderSide(
        color: isSelected ? MColor.primaryGreen : MColor.white,
        width: isSelected ? 3 : 0,
      ),
      child: Row(
        children: [
          Expanded(
            child: Column(
              children: [
                LineInfo(
                  title: 'Order',
                  content: Fn.convertOrderNumber(orderModel.orderNumber),
                ),
                const SizedBox(height: 10),
                LineInfo(
                  title: 'Giờ vào',
                  content: Fn.formatDate(
                    orderModel.dateCreated!,
                    DateFormat.Hm(),
                  ),
                ),
                const SizedBox(height: 10),
                LineInfo(
                  title: 'Bàn',
                  content: Fn.renderData(orderModel.table?.description),
                ),
                const SizedBox(height: 10),
                LineInfo(
                  title: 'Số món',
                  content: '${orderModel.orderDetails.length}',
                ),
              ],
            ),
          ),
          const SizedBox(width: 10),
          Column(
            children: [
              Icon(
                Icons.push_pin_outlined,
                size: 25,
                color: isPinned ? MColor.primaryGreen : MColor.danger,
              ),
              const SizedBox(height: 10),
              SizedBox(
                child: Text(
                  isPinned ? 'Bỏ ghim' : 'Ghim',
                  style: TextStyle(
                    fontWeight: FontWeight.bold,
                    color: isPinned ? MColor.primaryGreen : MColor.danger,
                    fontSize: 12,
                  ),
                ),
              )
            ],
          ),
        ],
      ),
    );
  }
}
