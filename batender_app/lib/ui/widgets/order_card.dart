import 'package:bartender_app/blocs/home/home_bloc.dart';
import 'package:bartender_app/models/order/order_model.dart';
import 'package:bartender_app/ui/widgets/card_custom.dart';
import 'package:bartender_app/ui/widgets/line_info.dart';
import 'package:bartender_app/utils/function_common.dart';
import 'package:bartender_app/utils/ui_setting.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:intl/intl.dart';

class OrderCard extends StatelessWidget {
  final OrderModel model;
  final bool isSelected;
  final bool isPinned;
  final bool showPinned;
  final Function()? onClick;
  final Function()? onPin;
  const OrderCard({
    super.key,
    required this.model,
    this.isSelected = false,
    this.isPinned = false,
    this.showPinned = true,
    this.onClick,
    this.onPin,
  });

  @override
  Widget build(BuildContext context) {
    return CardCustom(
      shadow: 20,
      padding: const EdgeInsets.all(15),
      borderSide: BorderSide(
        color: isPinned
            ? MColor.danger
            : isSelected
                ? MColor.primaryGreen
                : MColor.white,
        width: (isPinned || isSelected) ? 3 : 0,
      ),
      child: Row(
        children: [
          Expanded(
            child: InkWell(
              onTap: onClick,
              child: Column(
                children: [
                  LineInfo(
                    title: 'Order',
                    content: Fn.convertOrderNumber(model.orderNumber),
                  ),
                  const SizedBox(height: 10),
                  LineInfo(
                    title: 'Giờ vào',
                    content: Fn.formatDate(
                      model.dateCreated!,
                      DateFormat.Hm(),
                    ),
                  ),
                  const SizedBox(height: 10),
                  LineInfo(
                    title: 'Bàn',
                    content: model.table?.description,
                  ),
                  const SizedBox(height: 10),
                  LineInfo(
                    title: 'Số món',
                    content: model.orderDetails!.length,
                  ),
                ],
              ),
            ),
          ),
          Visibility(
            visible: showPinned,
            child: InkWell(
              onTap: onPin,
              child: Column(
                children: [
                  const SizedBox(width: 10),
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
            ),
          ),
        ],
      ),
    );
  }
}
