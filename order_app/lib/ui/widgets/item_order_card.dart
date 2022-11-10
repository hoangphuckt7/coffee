import 'package:orderr_app/models/item/item_model.dart';
import 'package:orderr_app/repositories/item_repo.dart';
import 'package:orderr_app/ui/controls/icon_btn.dart';
import 'package:orderr_app/utils/enum.dart';
import 'package:orderr_app/utils/function_common.dart';
import 'package:flutter/material.dart';

class ItemOrderCard extends StatelessWidget {
  final ItemModel model;
  final int? currentSugar;
  final int? currentIce;
  final void Function()? addToCart;
  final void Function()? increaseSugar;
  final void Function()? decreaseSugar;
  final void Function()? increaseIce;
  final void Function()? decreaseIce;
  const ItemOrderCard({
    super.key,
    required this.model,
    this.currentSugar = 100,
    this.currentIce = 100,
    this.addToCart,
    this.increaseSugar,
    this.decreaseSugar,
    this.increaseIce,
    this.decreaseIce,
  });

  @override
  Widget build(BuildContext context) {
    const double sizeIcon = 25;
    const TextStyle textStyle = TextStyle(
      fontWeight: FontWeight.bold,
      fontSize: 14.5,
    );
    return Row(
      children: [
        Expanded(
          flex: 4,
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
                  Fn.renderData(input: '${model.name}'),
                  style: textStyle,
                ),
              ),
              const SizedBox(height: 12),
              Row(
                children: [
                  const Expanded(
                    flex: 2,
                    child: SizedBox(
                      child: Text('Đường: '),
                    ),
                  ),
                  Expanded(
                    flex: 5,
                    child: Row(
                      children: [
                        IconBtn(
                          icons: Icons.add_circle_rounded,
                          onPressed: increaseSugar ?? () {},
                          size: sizeIcon,
                        ),
                        const SizedBox(width: 10),
                        SizedBox(child: Text('${currentSugar ?? 100}%')),
                        const SizedBox(width: 10),
                        IconBtn(
                          icons: Icons.remove_circle_rounded,
                          onPressed: decreaseSugar ?? () {},
                          btnBgColor: EColor.secondary,
                          size: sizeIcon,
                        ),
                      ],
                    ),
                  ),
                ],
              ),
              const SizedBox(height: 12),
              Row(
                children: [
                  const Expanded(
                    flex: 2,
                    child: SizedBox(child: Text('Đá: ')),
                  ),
                  Expanded(
                    flex: 5,
                    child: Row(
                      children: [
                        IconBtn(
                          icons: Icons.add_circle_rounded,
                          onPressed: increaseIce ?? () {},
                          size: sizeIcon,
                        ),
                        const SizedBox(width: 10),
                        SizedBox(child: Text('${currentIce ?? 100}%')),
                        const SizedBox(width: 10),
                        IconBtn(
                          icons: Icons.remove_circle_rounded,
                          btnBgColor: EColor.secondary,
                          onPressed: decreaseIce ?? () {},
                          size: sizeIcon,
                        ),
                      ],
                    ),
                  ),
                ],
              ),
            ],
          ),
        ),
        const SizedBox(width: 10),
        Expanded(
          flex: 1,
          child: IconBtn(
            icons: Icons.add,
            size: 40,
            btnBgColor: EColor.dark,
            onPressed: addToCart ?? () {},
          ),
        ),
      ],
    );
  }
}
