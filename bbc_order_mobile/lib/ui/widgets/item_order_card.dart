import 'package:bbc_order_mobile/models/item/item_model.dart';
import 'package:bbc_order_mobile/repositories/item_repo.dart';
import 'package:bbc_order_mobile/ui/controls/icon_btn.dart';
import 'package:bbc_order_mobile/utils/enum.dart';
import 'package:bbc_order_mobile/utils/function_common.dart';
import 'package:flutter/material.dart';

class ItemOrderCard extends StatelessWidget {
  final ItemModel model;
  const ItemOrderCard({
    super.key,
    required this.model,
  });

  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        Expanded(
          flex: 3,
          child: Image.network(ItemRepo.getImg(model.images?.first)),
        ),
        const SizedBox(width: 10),
        Expanded(
          flex: 5,
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              SizedBox(
                  child: Text(
                      Fn.renderData(input: '${model.name} ${model.name}'))),
              const SizedBox(height: 10),
              SizedBox(child: Text(Fn.renderData(input: model.name))),
              const SizedBox(height: 10),
              SizedBox(child: Text(Fn.renderData(input: model.name))),
            ],
          ),
        ),
        const SizedBox(width: 10),
        Expanded(
          flex: 1,
          child: IconBtn(
            icons: Icons.add,
            size: 30,
            btnBgColor: EColor.dark,
            onPressed: () {},
          ),
        ),
      ],
    );
  }
}
