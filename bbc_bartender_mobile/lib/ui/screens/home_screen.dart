import 'dart:developer';

import 'package:bbc_bartender_mobile/blocs/home/home_bloc.dart';
import 'package:bbc_bartender_mobile/repositories/category_repo.dart';
import 'package:bbc_bartender_mobile/repositories/floor_repo.dart';
import 'package:bbc_bartender_mobile/routes.dart';
import 'package:bbc_bartender_mobile/ui/controls/fill_btn.dart';
import 'package:bbc_bartender_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class HomeScreen extends StatelessWidget {
  const HomeScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return BlocProvider(
      create: (context) => HomeBloc(
        RepositoryProvider.of<CategoryRepo>(context),
        RepositoryProvider.of<FloorRepo>(context),
      )..add(InitialEvent()),
      child: BlocBuilder<HomeBloc, HomeState>(
        builder: (context, state) {
          if (state is DataLoadedState) {
            var data = state.data;
            return Container(
              child: Column(
                children: [
                  Text(data),
                  SizedBox(height: 50),
                  FillBtn(
                    title: "Về login",
                    onPressed: (() =>
                        Navigator.pushNamed(context, RouteName.Login)),
                  ),
                ],
              ),
            );
          } else if (state is ErrorState) {
            return Container(
              color: MColor.white,
              child: Center(
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    Text(state.errMsg),
                    SizedBox(height: 50),
                    FillBtn(
                      title: "Về login",
                      onPressed: (() =>
                          Navigator.pushNamed(context, RouteName.Login)),
                    ),
                  ],
                ),
              ),
            );
          } else {
            return Container(
              color: MColor.white,
              child: Center(
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    CircularProgressIndicator(),
                    SizedBox(height: 50),
                    FillBtn(
                      title: "Về login",
                      onPressed: (() =>
                          Navigator.pushNamed(context, RouteName.Login)),
                    ),
                  ],
                ),
              ),
            );
          }
        },
      ),
    );
  }
}
