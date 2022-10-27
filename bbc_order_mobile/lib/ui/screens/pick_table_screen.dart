// ignore_for_file: must_be_immutable

import 'package:bbc_order_mobile/blocs/pick_tabel/pick_table_bloc.dart';
import 'package:bbc_order_mobile/models/table/table_model.dart';
import 'package:bbc_order_mobile/ui/controls/fill_btn.dart';
import 'package:bbc_order_mobile/ui/widgets/frame_common.dart';
import 'package:bbc_order_mobile/ui/widgets/processing.dart';
import 'package:bbc_order_mobile/utils/enum.dart';
import 'package:bbc_order_mobile/utils/function_common.dart';
import 'package:bbc_order_mobile/utils/ui_setting.dart';
import 'package:dropdown_button2/custom_dropdown_button2.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class PickTableScreen extends StatelessWidget {
  PickTableScreen({super.key});
  bool isLoading = false;
  List<TableModel> lstTable = <TableModel>[];
  @override
  Widget build(BuildContext context) {
    return MainFrame(
      showBackBtn: false,
      showUserInfo: true,
      showLogoutBtn: true,
      child: Stack(
        children: [
          _processState(context),
          _main(context),
        ],
      ),
    );
  }

  Widget _processState(BuildContext context) {
    return BlocBuilder<PickTableBloc, PickTableState>(
      builder: (context, state) {
        bool isLoading = false;

        String loadingMsg = "";
        if (state is ErrorState) {
          Fn.showToast(EToast.danger, state.errMsg.toString());
        }
        return Processing(msg: loadingMsg, show: isLoading);
      },
    );
  }

  Widget _main(BuildContext context) {
    return Column(
      children: [
        const SizedBox(height: 10),
        FillBtn(title: 'Chuyển / Gộp bàn', onPressed: () {}),
        const SizedBox(height: 20),
        const Divider(
          color: MColor.primaryBlack,
          thickness: 2,
          indent: 50,
          endIndent: 50,
        ),
        const SizedBox(height: 20),
        const SizedBox(
          child: Text(
            'Chọn bàn order',
            style: TextStyle(
              fontSize: 20,
              fontWeight: FontWeight.bold,
              color: MColor.primaryBlack,
            ),
          ),
        ),
        const SizedBox(height: 20),
        SizedBox(
          width: Fn.getScreenWidth(context) * .6,
          child: Row(
            children: const [
              const Text("Khu vực:"),
CustomDropdownButton2(
        hint: 'Select Item',
        dropdownItems: ,
        value: selectedValue,
        onChanged: (value) {
          setState(() {
            selectedValue = value;
          });
        },
      ),
            ],
          ),
        ),
        const SizedBox(height: 20),
        FillBtn(title: 'Tiếp theo', onPressed: () {}),
      ],
    );
  }
}
