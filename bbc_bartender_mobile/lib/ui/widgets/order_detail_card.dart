import 'package:bbc_bartender_mobile/ui/widgets/card_custom.dart';
import 'package:flutter/material.dart';

class OrderDetailCard extends StatelessWidget {
  const OrderDetailCard({super.key});

  @override
  Widget build(BuildContext context) {
    return CardCustom(
      shadow: 20,
      edgeInsets: const EdgeInsets.all(15),
      child: Row(
        children: [
          //Imgae
          Expanded(
            child: Column(
              children: [],
            ),
          ),
        ],
      ),
    );
  }
}
