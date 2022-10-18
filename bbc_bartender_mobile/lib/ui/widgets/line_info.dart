import 'package:bbc_bartender_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';

class LineInfo extends StatelessWidget {
  final String title;
  final String content;
  final double? fontSize;
  const LineInfo({
    super.key,
    required this.title,
    required this.content,
    this.fontSize = 15,
  });

  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        Expanded(
          flex: 1,
          child: SizedBox(
            child: Text(
              '$title:',
              style: TextStyle(
                color: MColor.primaryBlack,
                fontWeight: FontWeight.bold,
                fontSize: fontSize,
              ),
            ),
          ),
        ),
        const SizedBox(width: 10),
        Expanded(
          flex: 2,
          child: SizedBox(
            child: Text(
              content,
              style: TextStyle(
                color: MColor.primaryBlack,
                fontSize: fontSize,
              ),
            ),
          ),
        ),
      ],
    );
  }
}