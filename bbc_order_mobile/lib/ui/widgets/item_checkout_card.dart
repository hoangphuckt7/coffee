import 'package:bbc_order_mobile/blocs/checkout/checkout_bloc.dart';
import 'package:bbc_order_mobile/models/order/detail_dct_model.dart';
import 'package:bbc_order_mobile/models/order/order_detail_create_model.dart';
import 'package:bbc_order_mobile/ui/controls/field_outline.dart';
import 'package:bbc_order_mobile/ui/controls/icon_btn.dart';
import 'package:bbc_order_mobile/ui/widgets/card_custom.dart';
import 'package:bbc_order_mobile/utils/const.dart';
import 'package:bbc_order_mobile/utils/enum.dart';
import 'package:bbc_order_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class ItemCheckoutCard extends StatelessWidget {
  final OrderDetailCreateModel model;
  final List<TextEditingController> listController;
  const ItemCheckoutCard({
    super.key,
    required this.model,
    required this.listController,
  });

  static const TextStyle textStyle = TextStyle(fontWeight: FontWeight.bold);
  static const double sizeIcon = 25;

  @override
  Widget build(BuildContext context) {
    return CardCustom(
      shadow: 10,
      borderSide: const BorderSide(color: MColor.primaryGreen),
      padding: const EdgeInsets.all(15),
      child: Column(
        children: [_itemInfo(context), _line(), _dct(context)],
      ),
    );
  }

  Widget _note(BuildContext context, DetailDctModel dct, int index) {
    return Row(
      crossAxisAlignment: CrossAxisAlignment.center,
      children: [
        const SizedBox(child: Text('Ghi chú: ', style: textStyle)),
        const SizedBox(width: 5),
        Expanded(
          child: FieldOutline(
            fieldKey: Key(index.toString()),
            controller: listController[index],
            fontSize: 12,
            onChanged: (val) {
              BlocProvider.of<CheckoutBloc>(context).add(
                ChangeNoteEvent(model, listController[index].text, index),
              );
            },
          ),
        ),
      ],
    );
  }

  Widget _sugarIce(BuildContext context, DetailDctModel dct, int index) {
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
                      onPressed: () {
                        BlocProvider.of<CheckoutBloc>(context).add(
                          ChangeSugarEvent(model, AppInfo.IncreaseStep, index),
                        );
                      },
                      size: sizeIcon,
                    ),
                    const SizedBox(width: 5),
                    SizedBox(child: Text('${dct.Sugar}%')),
                    const SizedBox(width: 5),
                    IconBtn(
                      icons: Icons.remove_circle_rounded,
                      btnBgColor: EColor.secondary,
                      onPressed: () {
                        BlocProvider.of<CheckoutBloc>(context).add(
                          ChangeSugarEvent(model, AppInfo.DecreaseStep, index),
                        );
                      },
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
                      onPressed: () {
                        BlocProvider.of<CheckoutBloc>(context).add(
                          ChangeIceEvent(model, AppInfo.IncreaseStep, index),
                        );
                      },
                      size: sizeIcon,
                    ),
                    const SizedBox(width: 5),
                    SizedBox(child: Text('${dct.Ice}%')),
                    const SizedBox(width: 5),
                    IconBtn(
                      icons: Icons.remove_circle_rounded,
                      btnBgColor: EColor.secondary,
                      onPressed: () {
                        BlocProvider.of<CheckoutBloc>(context).add(
                          ChangeIceEvent(model, AppInfo.DecreaseStep, index),
                        );
                      },
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

  Widget _dct(BuildContext context) {
    return SingleChildScrollView(
      child: Column(
        children: List.generate(model.listDct!.length, (i) {
          var dct = model.listDct![i];
          return Column(
            children: [
              _line(show: i > 0),
              _sugarIce(context, dct, i),
              _note(context, dct, i),
            ],
          );
        }),
      ),
    );
  }

  Widget _itemInfo(BuildContext context) {
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
                onPressed: () {
                  BlocProvider.of<CheckoutBloc>(context).add(
                    ChangeQuantityEvent(model, 1, listController),
                  );
                },
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
                btnBgColor: EColor.secondary,
                onPressed: () {
                  BlocProvider.of<CheckoutBloc>(context).add(
                    ChangeQuantityEvent(model, -1, listController),
                  );
                },
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
