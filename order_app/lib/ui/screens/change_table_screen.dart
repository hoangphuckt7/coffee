// ignore_for_file: must_be_immutable, unrelated_type_equality_checks

import 'package:orderr_app/blocs/change_table/change_table_bloc.dart';
import 'package:orderr_app/models/common/base_model.dart';
import 'package:orderr_app/models/order/order_create_model.dart';
import 'package:orderr_app/models/table/table_model.dart';
import 'package:orderr_app/routes.dart';
import 'package:orderr_app/ui/controls/fill_btn.dart';
import 'package:orderr_app/ui/widgets/dropdown_floor.dart';
import 'package:orderr_app/ui/widgets/dropdown_table.dart';
import 'package:orderr_app/ui/widgets/frame_common.dart';
import 'package:orderr_app/ui/widgets/popup_confirm.dart';
import 'package:orderr_app/ui/widgets/processing.dart';
import 'package:orderr_app/ui/widgets/title_custom.dart';
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
  bool isShowPopupConfirm = false;
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
      showUserInfo: false,
      showLogoutBtn: false,
      title: 'Chuyển / Gộp bàn',
      onWillPop: () => _back(context),
      onClickBackBtn: () => _back(context),
      child: Stack(
        children: [
          _main(context),
          _processState(context),
          _popupConfirmChange(context),
        ],
      ),
    );
  }

  Widget _processState(BuildContext context) {
    return BlocListener<ChangeTableBloc, ChangeTableState>(
      listener: (context, state) {
        if (state is CTGoToPickTableState) {
          Fn.showToast(
            eToast: EToast.success,
            msg: 'Chuyển / Gộp bàn thành công',
          );
          _back(context);
        }
      },
      child: BlocBuilder<ChangeTableBloc, ChangeTableState>(
        builder: (context, state) {
          bool isLoading = false;
          String loadingMsg = "";
          if (state is CTErrorState) {
            isShowPopupConfirm = false;
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
      ),
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
            label: 'Xác nhận',
            onPressed: () {
              if (_validate()) {
                BlocProvider.of<ChangeTableBloc>(context)
                    .add(CTShowPopupConfirmChangeEvent(true));
              }
              // if (_validate()) {
              // }
            },
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
            flex: 2,
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: const [TitleCustom(title: 'Bàn chuyển đi')],
            ),
          ),
          Expanded(
            flex: 5,
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
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Expanded(
            flex: 2,
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: const [TitleCustom(title: 'Bàn chuyển tới')],
            ),
          ),
          Expanded(
            flex: 5,
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

  Widget _popupConfirmChange(BuildContext context) {
    return BlocBuilder<ChangeTableBloc, ChangeTableState>(
      builder: (context, state) {
        if (state is CTShowPopupConfirmChangeState) {
          isShowPopupConfirm = state.isVisible;
        }
        return PopupConfirm(
          visible: isShowPopupConfirm,
          title:
              'Xác nhận chuyển bàn ${selectedTableOld?.description} qua ${selectedTableNew?.description}',
          onLeftBtnPressed: () {
            BlocProvider.of<ChangeTableBloc>(context)
                .add(CTShowPopupConfirmChangeEvent(false));
          },
          onRightBtnPressed: () {
            BlocProvider.of<ChangeTableBloc>(context).add(CTConfirmChangeEvent(
              selectedTableOld?.id,
              selectedTableNew?.id,
            ));
          },
        );
      },
    );
  }

  _validate() {
    bool isError = false;
    String errMsg = '';

    bool isValidTableOld =
        selectedTableOld?.id != null && selectedTableOld?.id != '';
    bool isValidTableNew =
        selectedTableNew?.id != null && selectedTableNew?.id != '';

    if (!isError && !isValidTableOld) {
      errMsg = 'Vui lòng chọn bàn cần chuyển đi';
      isError = true;
    }

    if (!isError && !isValidTableNew) {
      errMsg = 'Vui lòng chọn bàn cần chuyển tới';
      isError = true;
    }

    if (!isError && isValidTableOld && isValidTableNew) {
      if (selectedTableOld?.id == selectedTableNew?.id) {
        errMsg = 'Bàn chuyển đi trùng với bàn chuyển tới';
        isError = true;
      }
    }

    if (isError) {
      Fn.showToast(eToast: EToast.danger, msg: errMsg);
      return false;
    }

    return true;
  }

  _back(BuildContext context) => Fn.pushScreen(
        context,
        RouteName.pickTable,
        arguments: [order],
      );
}
