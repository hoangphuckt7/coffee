import 'package:bartender_app/utils/function_common.dart';
import 'package:bartender_app/utils/ui_setting.dart';
import 'package:flutter/material.dart';

class LineInfo extends StatelessWidget {
  final String title;
  final Color? titleColor;
  final dynamic content;
  final Color? contentColor;
  final bool isBoldContent;
  final String? errMsg;
  final double? fontSize;
  const LineInfo({
    super.key,
    required this.title,
    this.titleColor = MColor.primaryBlack,
    required this.content,
    this.contentColor = MColor.primaryBlack,
    this.isBoldContent = false,
    this.errMsg = 'không xác định',
    this.fontSize = 15,
  });

  @override
  Widget build(BuildContext context) {
    String convertTitle = '';
    if (title.isNotEmpty) {
      convertTitle = '$title:';
    }
    return Row(
      children: [
        Expanded(
          flex: 1,
          child: SizedBox(
            child: Text(
              convertTitle,
              style: TextStyle(
                color: titleColor,
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
              Fn.renderData(content, errMsg),
              style: TextStyle(
                color: contentColor,
                fontSize: fontSize,
                fontWeight: isBoldContent ? FontWeight.bold : FontWeight.normal,
              ),
            ),
          ),
        ),
      ],
    );
  }
}
