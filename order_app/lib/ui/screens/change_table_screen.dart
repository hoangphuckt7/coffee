// ignore_for_file: must_be_immutable

import 'package:orderr_app/blocs/change_table/change_table_bloc.dart';
import 'package:orderr_app/models/common/base_model.dart';
import 'package:orderr_app/models/order/order_create_model.dart';
import 'package:orderr_app/models/table/table_model.dart';
import 'package:orderr_app/routes.dart';
import 'package:orderr_app/ui/controls/fill_btn.dart';
import 'package:orderr_app/ui/widgets/dropdown_floor.dart';
import 'package:orderr_app/ui/widgets/dropdown_table.dart';
import 'package:orderr_app/ui/widgets/frame_common.dart';
import 'package:orderr_app/ui/widgets/processing.dart';
import 'package:orderr_app/utils/enum.dart';
import 'package:orderr_app/utils/function_common.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:orderr_app/utils/ui_setting.dart';

class ChangeTableScreen extends StatelessWidget {
  final OrderCreateModel? order;
  ChangeTableScreen({
    super.key,
    this.order,
  });

  bool isLoading = false;
  List<BaseModel> lstFloor = <BaseModel>[];
  List<TableModel> lstTableOld = <TableModel>[];
  List<TableModel> lstTableNew = <TableModel>[];

  BaseModel? selectedFloorOld;
  BaseModel? selectedFloorNew;

  TableModel? selectedTableOld;
  TableModel? selectedTableNew;

  final TextStyle txtStyleFT = const TextStyle(fontWeight: FontWeight.bold);

  @override
  Widget build(BuildContext context) {
    return MainFrame(
      showBackBtn: true,
      showUserInfo: true,
      showLogoutBtn: true,
      onWillPop: () => _back(context),
      onClickBackBtn: () => _back(context),
      child: Stack(
        children: [
          _main(context),
          _processState(context),
        ],
      ),
    );
  }

  Widget _processState(BuildContext context) {
    return BlocBuilder<ChangeTableBloc, ChangeTableState>(
      builder: (context, state) {
        bool isLoading = false;
        String loadingMsg = "";
        if (state is CTErrorState) {
          Fn.showToast(eToast: EToast.danger, msg: state.errMsg.toString());
        } else if (state is CTUpdatedLoadingState) {
          isLoading = state.isLoading;
          loadingMsg = state.labelLoading;
        } else if (state is CTLoadedFloorTableState) {
          selectedFloorOld = state.selectedFloorOld;
          selectedFloorNew = state.selectedFloorNew;

          selectedTableOld = state.selectedTableOld;
          selectedTableNew = state.selectedTableNew;

          lstFloor = state.lstFloor;

          lstTableOld = state.lstTableOld;
          lstTableNew = state.lstTableNew;
        }
        return Processing(msg: loadingMsg, show: isLoading);
      },
    );
  }

  Widget _main(BuildContext context) {
    return Container(
      padding: const EdgeInsets.all(10),
      child: Column(
        children: [
          Expanded(
            child: Column(
              children: [
                Expanded(child: _ftOld(context)),
                const Divider(
                  color: MColor.primaryBlack,
                  thickness: 1,
                  indent: 20,
                  endIndent: 20,
                ),
                Expanded(child: _ftNew(context)),
              ],
            ),
          ),
          FillBtn(
            title: 'Xác nhận',
            onPressed: () => {},
          ),
          const SizedBox(height: 20),
        ],
      ),
    );
  }

  Widget _ftOld(BuildContext context) {
    return SizedBox(
      width: Fn.getScreenWidth(context) * .8,
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Expanded(
            flex: 1,
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [_title(context, 'Chuyển / Gộp bàn')],
            ),
          ),
          Expanded(
            flex: 3,
            child: Column(
              children: [
                Row(children: [Text("Khu vực:", style: txtStyleFT)]),
                BlocBuilder<ChangeTableBloc, ChangeTableState>(
                  builder: (context, state) {
                    if (state is CTChangedFloorOldState) {
                      selectedFloorOld = state.floor;
                      selectedTableOld = state.selectedTable;
                      lstTableOld = state.listTable;
                    }
                    return DropdownFloor(
                      listFloor: lstFloor,
                      selectedFloor: selectedFloorOld,
                      onChanged: (value) {
                        BlocProvider.of<ChangeTableBloc>(context)
                            .add(CTChangeFloorOldEvent(value));
                      },
                    );
                  },
                ),
                const SizedBox(height: 20),
                Row(children: [Text("Bàn:", style: txtStyleFT)]),
                BlocBuilder<ChangeTableBloc, ChangeTableState>(
                  builder: (context, state) {
                    if (state is CTChangedTableOldState) {
                      selectedTableOld = state.table;
                    }
                    return DropdownTable(
                      listTable: lstTableOld,
                      selectedTable: selectedTableOld,
                      onChanged: (value) {
                        BlocProvider.of<ChangeTableBloc>(context)
                            .add(CTChangeTableOldEvent(value));
                      },
                    );
                  },
                ),
              ],
            ),
          ),
        ],
      ),
    );
  }

  Widget _ftNew(BuildContext context) {
    return SizedBox(
      width: Fn.getScreenWidth(context) * .8,
      child: Column(
        children: [
          Expanded(
            flex: 1,
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [_title(context, 'Tới bàn')],
            ),
          ),
          Expanded(
            flex: 3,
            child: Column(
              children: [
                Row(children: [Text("Khu vực:", style: txtStyleFT)]),
                BlocBuilder<ChangeTableBloc, ChangeTableState>(
                  builder: (context, state) {
                    if (state is CTChangedFloorNewState) {
                      selectedFloorNew = state.floor;
                      selectedTableNew = state.selectedTable;
                      lstTableNew = state.listTable;
                    }
                    return DropdownFloor(
                      listFloor: lstFloor,
                      selectedFloor: selectedFloorNew,
                      onChanged: (value) {
                        BlocProvider.of<ChangeTableBloc>(context)
                            .add(CTChangeFloorNewEvent(value));
                      },
                    );
                  },
                ),
                const SizedBox(height: 20),
                Row(children: [Text("Bàn:", style: txtStyleFT)]),
                BlocBuilder<ChangeTableBloc, ChangeTableState>(
                  builder: (context, state) {
                    if (state is CTChangedTableNewState) {
                      selectedTableNew = state.table;
                    }
                    return DropdownTable(
                      listTable: lstTableNew,
                      selectedTable: selectedTableNew,
                      onChanged: (value) {
                        BlocProvider.of<ChangeTableBloc>(context)
                            .add(CTChangeTableNewEvent(value));
                      },
                    );
                  },
                ),
              ],
            ),
          ),
        ],
      ),
    );
  }

  Widget _title(BuildContext context, String title) {
    return SizedBox(
      child: Text(
        title,
        style: const TextStyle(
          fontWeight: FontWeight.bold,
          fontSize: ScreenSetting.fontSize + 3,
        ),
      ),
    );
  }

  _back(BuildContext context) =>
      Fn.pushScreen(context, RouteName.pickTable, arguments: [order]);
}
