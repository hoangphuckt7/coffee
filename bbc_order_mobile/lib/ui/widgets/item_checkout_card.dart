import 'package:bbc_order_mobile/models/order/detail_dct_model.dart';
import 'package:bbc_order_mobile/models/order/order_detail_create_model.dart';
import 'package:bbc_order_mobile/ui/controls/field_outline.dart';
import 'package:bbc_order_mobile/ui/controls/icon_btn.dart';
import 'package:bbc_order_mobile/ui/widgets/card_custom.dart';
import 'package:bbc_order_mobile/utils/enum.dart';
import 'package:bbc_order_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';

class ItemCheckoutCard extends StatelessWidget {
  final OrderDetailCreateModel model;
  final void Function()? increaseQuantity;
  final void Function()? decreaseQuantity;
  final void Function()? increaseSugar;
  final void Function()? decreaseSugar;
  final void Function()? increaseIce;
  final void Function()? decreaseIce;
  final void Function(String)? onNoteChange;
  const ItemCheckoutCard({
    super.key,
    required this.model,
    this.increaseQuantity,
    this.decreaseQuantity,
    this.increaseSugar,
    this.decreaseSugar,
    this.increaseIce,
    this.decreaseIce,
    this.onNoteChange,
  });

  static const TextStyle textStyle = TextStyle(fontWeight: FontWeight.bold);
  static const double sizeIcon = 20;

  @override
  Widget build(BuildContext context) {
    return CardCustom(
      shadow: 10,
      borderSide: const BorderSide(color: MColor.primaryGreen),
      padding: const EdgeInsets.all(15),
      child: Column(
        children: [_itemInfo(), _line(), _dct()],
      ),
    );
  }

  Widget _note(DetailDctModel dct) {
    var noteController = TextEditingController();
    return Row(
      crossAxisAlignment: CrossAxisAlignment.center,
      children: [
        const SizedBox(child: Text('Ghi chú: ', style: textStyle)),
        const SizedBox(width: 5),
        Expanded(
          child: FieldOutline(
            controller: noteController,
            fontSize: 12,
            onChanged: onNoteChange,
          ),
        ),
      ],
    );
  }

  Widget _sugarIce(DetailDctModel dct) {
    return Row(
      children: [
        Expanded(
          child: Row(
            children: [
              Expanded(
                flex: 1,
                child: Row(
                  crossAxisAlignment: CrossAxisAlignment.center,
                  children: [
                    const SizedBox(child: Text('Đường: ', style: textStyle)),
                    const SizedBox(width: 5),
                    IconBtn(
                      icons: Icons.add_circle_rounded,
                      onPressed: increaseSugar ?? () {},
                      size: sizeIcon,
                    ),
                    const SizedBox(width: 5),
                    SizedBox(child: Text('${dct.Sugar}%')),
                    const SizedBox(width: 5),
                    IconBtn(
                      icons: Icons.remove_circle_rounded,
                      btnBgColor: EColor.danger,
                      onPressed: decreaseSugar ?? () {},
                      size: sizeIcon,
                    ),
                  ],
                ),
              ),
              Expanded(
                flex: 1,
                child: Row(
                  crossAxisAlignment: CrossAxisAlignment.center,
                  children: [
                    const SizedBox(child: Text('Đá: ', style: textStyle)),
                    const SizedBox(width: 5),
                    IconBtn(
                      icons: Icons.add_circle_rounded,
                      onPressed: increaseIce ?? () {},
                      size: sizeIcon,
                    ),
                    const SizedBox(width: 5),
                    SizedBox(child: Text('${dct.Ice}%')),
                    const SizedBox(width: 5),
                    IconBtn(
                      icons: Icons.remove_circle_rounded,
                      btnBgColor: EColor.danger,
                      onPressed: decreaseIce ?? () {},
                      size: sizeIcon,
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

  Widget _dct() {
    return SingleChildScrollView(
      child: Column(
        children: List.generate(model.listDct!.length, (i) {
          var dct = model.listDct![i];
          return Column(
            children: [
              _line(show: i > 0),
              _sugarIce(dct),
              _note(dct),
            ],
          );
        }),
      ),
    );
  }

  Widget _itemInfo() {
    return Row(
      children: [
        Expanded(
          flex: 6,
          child: Row(
            children: [
              const SizedBox(
                child: Text(
                  'Tên món:',
                  style: textStyle,
                ),
              ),
              const SizedBox(width: 5),
              Expanded(child: Text(model.item!.name!)),
            ],
          ),
        ),
        const SizedBox(width: 10),
        Expanded(
          flex: 5,
          child: Row(
            children: [
              const SizedBox(
                child: Text(
                  'Số lượng:',
                  style: textStyle,
                ),
              ),
              const SizedBox(width: 10),
              IconBtn(
                icons: Icons.add_circle_rounded,
                onPressed: increaseQuantity ?? () {},
                size: sizeIcon,
              ),
              const SizedBox(width: 2),
              Expanded(
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    SizedBox(child: Text('${model.quantity}')),
                  ],
                ),
              ),
              const SizedBox(width: 2),
              IconBtn(
                icons: Icons.remove_circle_rounded,
                btnBgColor: EColor.danger,
                onPressed: decreaseQuantity ?? () {},
                size: sizeIcon,
              ),
            ],
          ),
        ),
      ],
    );
  }

  Widget _line({show = true}) {
    return Visibility(
      visible: show,
      child: const Padding(
        padding: EdgeInsets.symmetric(horizontal: 0, vertical: 5),
        child: Divider(color: MColor.primaryBlack, thickness: 1),
      ),
    );
  }
}
